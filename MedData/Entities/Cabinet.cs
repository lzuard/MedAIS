using MedData.Entities.Base;
using System.Collections.Generic;

namespace MedData.Entities
{
    public class Cabinet : Entity
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Number of the cabinet, example: A-207
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Name of the cabinet 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Examination> Examinations { get; set; }
    }
}
