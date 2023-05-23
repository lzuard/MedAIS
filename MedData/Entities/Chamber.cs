using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MedData.Entities.Base;

namespace MedData.Entities 
{
    public class Chamber : Entity
    {
        /// <summary>
        /// Chambers department id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Doctors id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Number of the chamber, example A-207
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gender of patients in this chamber
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Bed count in this chamber
        /// </summary>
        public int BedCount { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<PatientInChamber> PatientsInChamber { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        [InverseProperty("OldChamber")]
        public ICollection<Transaction> OldChamber { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        [InverseProperty("NewChamber")]
        public ICollection<Transaction> NewChamber { get; set; }
    }
}
