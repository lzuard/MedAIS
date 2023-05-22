using Microsoft.EntityFrameworkCore;

namespace MedApp.Models.Data
{
    internal partial class ApplicationContext: DbContext
    {
        public ApplicationContext() 
        { 
            Database.EnsureCreated(); //Create db if not existing
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testdb1;Username=postgres;Password=123");
        }
    }
}
