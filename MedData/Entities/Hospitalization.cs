using System.Collections.Generic;
using MedData.Entities.Base;

namespace MedData.Entities
{
    public class Hospitalization : Entity
    {
        /// <summary>
        /// Medical Card ID
        /// </summary>
        public int MedCardId { get; set; }

        /// <summary>
        /// Date when hospitalization started
        /// </summary>
        public DateTime HospitalizationDate { get; set; }

        /// <summary>
        /// Method how hospitallization happend
        /// </summary>
        public HospitalizationMethod HospitalizationMethod { get; set; }

        /// <summary>
        /// Patient's Complaints
        /// </summary>
        public string Сomplaints { get; set; }

        /// <summary>
        /// Patient's illnes anamnesis
        /// </summary>
        public string AnamnesisMorbi { get; set; }

        /// <summary>
        /// Short diagnosis
        /// </summary>
        public string ShortDiagnosis { get; set; }

        /// <summary>
        /// Is cur hospitalization active
        /// </summary>
        public bool IsAcrive { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public MedCard MedCard { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<AnamnesisVitae> AnamnesisVitae { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Diagnoses> Diagnoses { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Checkups> Checkups { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Examination> Examinations { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Treatment> Treatments { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }
}
