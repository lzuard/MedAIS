using MedData.Entities.Base;
using System.Collections.Generic;

namespace MedData.Entities
{
    public class Allergen : Entity
    {
        /// <summary>
        /// Id of the cabinet
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
