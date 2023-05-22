
using System;

namespace MedApp.Models.Entities
{
    public class Hospitalization
    {
        /// <summary>
        /// Hospitalization ID
        /// </summary>
        public int Id { get; set; }

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
        public HospitalizationMethod HospitalizationMethod { get; set;}

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
    }
}
