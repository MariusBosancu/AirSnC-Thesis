using Microsoft.EntityFrameworkCore;

namespace AirSnC.Models
{
    public class SignInDbContext:DbContext
    {
        internal static SignInDbContext singIn;

        public SignInDbContext(DbContextOptions<SignInDbContext> options) : base(options) 
        {
        }
        public DbSet<SignIn> SingIns { get; set; }
    }
}
