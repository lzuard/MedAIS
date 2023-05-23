using System.Collections.Generic;
using MedData.Entities.Base;

namespace MedData.Entities
{
    public class Position : Entity
    {
        /// <summary>
        /// Name of the position
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category of the position
        /// </summary>
        public PostionCategory Category { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<User> Users { get; set; }

    }
}
