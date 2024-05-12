using Microsoft.EntityFrameworkCore;
using Online_Voting_System.Models;

namespace Online_Voting_System.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        
         public DbSet<User> User {  get; set; }
        
    }
}
