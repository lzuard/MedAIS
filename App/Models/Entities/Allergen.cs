using System.Collections.Generic;

namespace MedApp.Models.Entities
{
    class Allergen
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Allergen
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// EF Navigation property
        /// </summary>
        public ICollection<Allergy> Allergies { get; set; }
    }
}
