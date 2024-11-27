using NavXpert.Data;
using NavXpert.Models;
using BCrypt;
using Microsoft.AspNetCore.Mvc;

namespace NavXpert.Services
{
    public class UserRegistration
    {
        private readonly AppDbContext _context;

        public UserRegistration(AppDbContext context)
        {   
            _context = context;
        }
        public async Task<User> Register(string Username,string firstName, string lastName, string email, string phoneNumber, string password, DateOnly dob) {

           

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);


                var user = new User
                {
                    UserName = Username,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = passwordHash,
                    Email = email,
                    DOB = dob,
                    PhoneNumber = phoneNumber,

                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return user;
      
            


       
        
        }
    }
}
