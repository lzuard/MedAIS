using System.ComponentModel.DataAnnotations.Schema;
using MedData.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace MedData.Entities
{
    public class Checkups : Entity
    {
        /// <summary>
        /// Hospitalization Id
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Chuck up Id
        /// </summary>
        public int CheckupId { get; set; }

        /// <summary>
        /// Date of checkup
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        [ForeignKey("HospitalizationId")]
        public Hospitalization Hospitalization { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        [ForeignKey("CheckupId")]
        public Checkup Checkup { get; set; }

    }
}
