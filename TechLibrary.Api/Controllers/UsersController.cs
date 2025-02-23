using Microsoft.AspNetCore.Mvc;
using TechLibrary.Comunication.Request;
using TechLibrary.Comunication.Responses;
using TechLibrary.Execptions;
using TechLibrary.Usecases.Users.Cases.Register;

namespace TechLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("me")]
        public IActionResult me()
        {
            return Ok("UsersController");
        }

        [HttpPost]
        [Route("Createuser")]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Createuser(RequestUserJson request)
        {
            try
            {
                RegisterUserUseCase usecase = new RegisterUserUseCase();

                ResponseRegisterUserJson response = usecase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (TechLibraryExeptions ex)
            {
                return BadRequest(new ResponseErrorMessageJson
                {
                    Errors = ex.GetErrorMessages()
                });

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessageJson
                {
                    Errors = ["Erro Desconhecido"]
                });
            }
        }

        [HttpPut("updateUser")]
        public IActionResult updateUser()
        {
            return Ok();
        }

        [HttpDelete("deleteUser")]
        public IActionResult deleteUser()
        {
            return Ok();
        }
    }
}
