using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NavXpert.Data;
using NavXpert.DTOs;
using NavXpert.Models;
using NavXpert.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;



namespace NavXpert.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserAuthentification _userAuth;

        private readonly UserManager<User> _userManager;

        private readonly IConfiguration _configuration;
        private readonly AppDbContext  _appDbContext;

        public UserAuthController(IConfiguration configuration, UserManager<User> userManager, UserAuthentification UserAuth)
        {
            _configuration = configuration;

            _userManager = _userManager;
           
            _userAuth = UserAuth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDTO loginDto)
        {

            User user = await _userAuth.Login(loginDto.Email, loginDto.Password);
           
            if (user != null )
            {
                var token =  GenerateJwtToken(user);


                var userToken = new IdToken { 

                    UserId = user.Id,
                    Token = token, 
                    ExpiryDate = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpireMinutes"])) ,

                
                };

                await _appDbContext.IdTokens.AddAsync(userToken);
                _appDbContext.SaveChanges();


                return Ok(new { token });
            }
            return Unauthorized();
        }
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}



