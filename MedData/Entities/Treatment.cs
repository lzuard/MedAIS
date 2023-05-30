using MedData.Entities.Base;
using System;

namespace MedData.Entities
{
    public class Treatment : Entity
    {
        /// <summary>
        /// Id of the hospitalization
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Date of the treatment start
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date of the treatment end
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Medication name
        /// </summary>
        public string Medication { get; set; }

        /// <summary>
        /// Medication volume to take
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Frequency of medication 
        /// </summary>
        public string Frequency { get; set; }

        /// <summary>
        /// The result of the treatment
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// If treatment has been stopped
        /// </summary>
        public bool IsStopped { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }
    }
}
