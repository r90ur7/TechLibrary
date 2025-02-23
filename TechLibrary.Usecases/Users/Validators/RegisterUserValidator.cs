using FluentValidation;
using TechLibrary.Comunication.Request;

namespace TechLibrary.Usecases.Users.Validators
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is invalid");
            When(request => !string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password is required")
                    .MinimumLength(8)
                    .WithMessage("Password must be at least 8 characters");
            });
        }
    }
}
