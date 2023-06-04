using MedData.Entities.Base;
using System.Collections.Generic;

namespace MedData.Entities
{
    public class Diagnosis : Entity
    {
        /// <summary>
        /// MKB-10 code id
        /// </summary>
        public int MkbId { get; set; }

        /// <summary>
        /// Id of the hospitalization
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Date when a doctor made this diagnosis
        /// </summary>
        public DateTime Date { get; set; }


        /// <summary>
        /// Syndromic diagnosis
        /// </summary>
        public string SyndromicDiagnosis { get; set; }

        /// <summary>
        /// Clinical diagnosis
        /// </summary>
        public string ClinicalDiagnosis { get; set; }

        /// <summary>
        /// The reason why this diagnosis has been chosen
        /// </summary>
        public string Rationale { get; set; }

        /// <summary>
        /// Etiology and pathogenesis
        /// </summary>
        public string EtiologyPathogenesis { get; set; }

        /// <summary>
        /// If this diagnosis is main
        /// </summary>
        public bool IsMain { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Mkb Mkb { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }
    }
}
