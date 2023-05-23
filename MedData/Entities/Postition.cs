using System.Collections.Generic;
using MedData;

namespace MedData.Entities
{
    public class Position
    {
        /// <summary>
        /// Id of the position
        /// </summary>
        public int Id { get; set; }

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
