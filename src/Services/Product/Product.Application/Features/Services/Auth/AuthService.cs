using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Exceptions;
using Product.Application.Features.Services.Auth.Dtos;
using Product.Domain.Entities;

namespace Product.Application.Features.Services.Auth
{
    public class AuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;
        public AuthService(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null) throw new BusinessLogicException("User not found"); ;

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
                return await CreateUserDtoObjByUser(user);

            throw new BusinessLogicException("Wrong password");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return await CreateUserDtoObjByUser(user);
            }
            else
            {
                var msg = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BusinessLogicException(msg);
            }

            return null;
        }

        private async Task<UserDto> CreateUserDtoObjByUser(AppUser user)
        {
            return new UserDto
            {
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
            };
        }
    }
}

