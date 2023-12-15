using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Models;
using Product.Application.Features.Services.Auth;
using Product.Application.Features.Services.Auth.Dtos;

namespace Product.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly AuthService _authService;

        public AuthController(IMediator mediator, AuthService authService) : base(null)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.Register(dto);

            var response = new ResponseMessage(result: result);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);

            var response = new ResponseMessage(result: result);
            return Ok(response);
        }
    }
}
