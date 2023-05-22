using Microsoft.EntityFrameworkCore;

namespace MedApp.Models.Entities
{
    internal partial class ApplicationContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<AnamnesisVitae> AnamnesisVitae { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<Checkups> Checkups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Diagnoses> Diagnoses { get; set; }
        public DbSet<Diagnosis> Diagnosis_s { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Hospitalization> Hospitalizations { get; set;}
        public DbSet<MedCard> MedCards { get; set; }
        public DbSet<Mkb> Mkbs { get; set; }
        public DbSet<PatientInChamber> PatientInChambers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Сheckup> Checkup_s { get; set; }

        
    }
}
