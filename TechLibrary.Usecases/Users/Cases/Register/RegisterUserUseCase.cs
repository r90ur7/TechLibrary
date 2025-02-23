using Tech.Data;
using Tech.Data.domain.Entities;
using TechLibrary.Comunication.Request;
using TechLibrary.Comunication.Responses;
using TechLibrary.Execptions;
using TechLibrary.Usecases.Users.Validators;

namespace TechLibrary.Usecases.Users.Cases.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestUserJson request)
        {
            Validate(request);

            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };
            var dbcontext = new TechLibraryContext();
            dbcontext.Users.Add(entity);
            dbcontext.SaveChanges();
            return new ResponseRegisterUserJson
            {
                Name = request.Name,
            };
        }

        private void Validate(RequestUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
