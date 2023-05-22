using Microsoft.EntityFrameworkCore;

namespace MedApp.Models.Data
{
    class ApplicationContext: DbContext
    {
        #region Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        #endregion

        public ApplicationContext() 
        { 
            Database.EnsureCreated(); //Create db if not existing
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testdb1;Username=postgres;Password=123");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
