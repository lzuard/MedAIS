using System;

namespace MedApp.Models.Entities
{
    public class Checkups
    {
        /// <summary>
        /// Hospitalizatio Id
        /// </summary>
        public int HospitaliztionId { get; set; }

        /// <summary>
        /// Chuck up Id
        /// </summary>
        public int CheckUpId { get; set; }

        /// <summary>
        /// Date of checkup
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Checkups Checkup_s { get; set; }

    }
}
