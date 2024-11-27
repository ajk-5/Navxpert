using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NavXpert.Data;
using NavXpert.DTOs;
using NavXpert.Models;
using NavXpert.Services;

namespace NavXpert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly UserRegistration _userReg;

        public UserRegistrationController(UserRegistration  UserReg) { 
        _userReg = UserReg;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userRegisterDTO.Password != userRegisterDTO.ConfirmPassword)
            {
                return BadRequest("Password do not match");
            }

            try
            {
                var newUser = await _userReg.Register(
                    userRegisterDTO.UserName,
                    userRegisterDTO.FirstName,
                    userRegisterDTO.LastName,
                    userRegisterDTO.Email,
                    userRegisterDTO.PhoneNumber,
                    userRegisterDTO.Password,
                    userRegisterDTO.DOB
                );

                return Ok(new { Message = "Registration successful.", User = newUser });
            }
            catch (ArgumentException ex)
            {
              
                return BadRequest(new { Error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, new { Error = "An unexpected error occurred."+ex.Message });
            }
        }
        

    }
}
