using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repetition.Abstractions;
using RepetitionCore.Authentication;
using RepetitionInfrastructure.ServiceInterfaces;
using RepetitionInfrastructure.Services;

namespace Repetition.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authorBookService;
        public AuthenticationController(IAuthenticationService authorBookService)
        {
            _authorBookService = authorBookService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var register = await _authorBookService.RegisterAsync(model);

            switch (register)
            {
                case "UserExists":
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
                case "CreationFailed":
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("Register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var registerAdmin = await _authorBookService.RegisterAdminAsync(model);

            switch (registerAdmin)
            {
                case "UserExists":
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
                case "CreationFailed":
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var registerAdmin = await _authorBookService.LoginAsync(model);

            switch (registerAdmin)
            {
                case "Unauthorized":
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }

            return Ok(registerAdmin);
        }
    }
}