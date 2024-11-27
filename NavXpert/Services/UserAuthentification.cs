using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavXpert.Data;
using NavXpert.Models;


namespace NavXpert.Services
{
    public class UserAuthentification
    {

        private readonly AppDbContext _appDbContext;

        public UserAuthentification(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> Login(string email, string password)
        {
          
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }
            return user;
        }
    }
}