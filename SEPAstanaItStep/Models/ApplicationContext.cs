using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace SEPAstanaItStep.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> person { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
