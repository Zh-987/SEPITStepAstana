using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace SEPAstanaItStep.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> users { get; set; } = null!;
        public DbSet<Company> companies { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
