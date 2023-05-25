using System.Collections.Generic;
using MedData.Entities.Base;

namespace MedData.Entities
{
    public class MedCard : Entity
    {
        /// <summary>
        /// Patients living adress
        /// </summary>
        public int AddressID { get; set; }

        /// <summary>
        /// Patients surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Patients name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Patients Patronumic
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Patients gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Patents birthday
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Patient OMS number
        /// </summary>
        public string OmsNumber { get; set; }

        /// <summary>
        /// Patients passport series
        /// </summary>
        public string PassportSeries { get; set; }

        /// <summary>
        /// Patients passport number
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Patients phone number
        /// </summary>
        public string MainPhone { get; set; }

        /// <summary>
        /// Patient Relatives phone number
        /// </summary>
        public string ExtraPhone { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Allergy> Allergies { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<PatientInChamber> PatientInChambers { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Hospitalization> Hospitalizations { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name[0] + ". " + Patronymic[0] + ".";
        }
    }
}
