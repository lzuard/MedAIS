using System.Collections.Generic;

namespace MedApp.Models.Entities
{
    public class Сheckup
    {
        /// <summary>
        /// Id of the checkup
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// External inspection
        /// </summary>
        public string View {get; set; }

        /// <summary>
        /// Examination of skin and visible mucous membranes
        /// </summary>
        public string Skin { get; set; }

        /// <summary>
        /// Cardiovascular System
        /// </summary>
        public string Heart { get;set; }

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
        public ICollection<Checkups> Checkups { get; set; }
    }
}
