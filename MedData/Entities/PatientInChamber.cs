using MedData.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace MedData.Entities
{
    public class PatientInChamber : Entity
    {
        /// <summary>
        /// Id of the Hospitalization (patient)
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Id of the chamber
        /// </summary>
        public int ChamberId { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Chamber Chamber { get; set; }
    }
}
