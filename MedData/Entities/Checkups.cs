using MedData.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace MedData.Entities
{
    public class Checkups : Entity
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
        public Checkup Checkup_s { get; set; }

    }
}
