﻿namespace MedApp.Models.Entities
{
    public class Diagnoses
    {
        /// <summary>
        /// Id of the hospitalization
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Id of the diagnosis
        /// </summary>
        public int DiagnosisId { get; set; }

        /// <summary>
        /// If cur diagnisis is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Diagnosis Diagnosis { get; set; }
    }
}