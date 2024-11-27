using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NavXpert.Models;

namespace NavXpert.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration; //attribut configuration

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("bdd"));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<IdToken> IdTokens {get; set;}

        
    }
}
