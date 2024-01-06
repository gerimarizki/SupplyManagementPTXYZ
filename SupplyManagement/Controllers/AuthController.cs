using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplyManagement.DTOs.Authorize;
using SupplyManagement.Services;
using System.Net;
using SupplyManagement.Handlers;

namespace SupplyManagement.Controllers
{
    [ApiController]
    [Route("Api/Authentication")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationServices _authService;

        public AuthController(AuthenticationServices authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterDTO registerDto)
        {
            var createRegister = _authService.Register(registerDto);
            if (createRegister == null)
            {
                return BadRequest(new HandlerForResponse<RegisterDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new HandlerForResponse<RegisterDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createRegister
            });
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginDTO loginDto)
        {
            var loginResult = _authService.Login(loginDto);
            if (loginResult == "USER_NOT_FOUND")
            {
                return NotFound(new HandlerForResponse<LoginDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email is incorrect"
                });
            }

            if (loginResult == "INVALID_PASSWORD")
            {
                return BadRequest(new HandlerForResponse<LoginDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Password is incorrect"
                });
            }

            if (loginResult == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HandlerForResponse<LoginDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Error retrieving when creating token"
                });
            }

            return Ok(new HandlerForResponse<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "You are now logged in",
                Data = loginResult
            });
        }
    }
}
