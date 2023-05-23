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
        public string ClinaclDiagnosis { get; set; }

        /// <summary>
        /// The reason why this diagnosis has been chosen
        /// </summary>
        public string Rationale { get; set; }

        /// <summary>
        /// Etiology and patogenesis
        /// </summary>
        public string EtiologyPathogenesis { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Mkb Mkb { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Diagnoses> Diagnoses { get; set; }
    }
}
