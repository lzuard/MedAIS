using MedData.Entities.Base;
using System.Collections.Generic;

namespace MedData.Entities
{
    public class Checkup : Entity
    {
        /// <summary>
        /// Doctor who made this checkup
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Hospitalization Id
        /// </summary>
        public int HospitalizationId { get; set; }

        /// <summary>
        /// Date of checkup
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// External inspection
        /// </summary>
        public string View { get; set; }

        /// <summary>
        /// Examination of skin and visible mucous membranes
        /// </summary>
        public string Skin { get; set; }

        /// <summary>
        /// Cardiovascular System
        /// </summary>
        public string Heart { get; set; }

        /// <summary>
        /// Digestive system
        /// </summary>
        public string Stomach { get; set; }

        /// <summary>
        /// Endocrine System
        /// </summary>
        public string Hormones { get; set; }

        /// <summary>
        /// Genitourinary System
        /// </summary>
        public string Genitourinary { get; set; }

        /// <summary>
        /// Nervous System
        /// </summary>
        public string Nervous { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Hospitalization Hospitalization { get; set; }
    }
}
