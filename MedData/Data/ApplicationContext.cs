using MedData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedData.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AnamnesisVitae> AnamnesisVitae { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Hospitalization> Hospitalizations { get; set; }
        public DbSet<MedCard> MedCards { get; set; }
        public DbSet<Mkb> Mkb { get; set; }
        public DbSet<PatientInChamber> PatientInChambers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Checkup> Checkup { get; set; }


        public ApplicationContext(DbContextOptions options) : base(options) { }
    }
}
