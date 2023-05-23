using System.Collections.Generic;

namespace MedData.Entities
{
    public class Department
    {
        /// <summary>
        /// Department Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Department name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Cabinet> Cabinets { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Chamber> Chambers { get; set; }
    }
}
