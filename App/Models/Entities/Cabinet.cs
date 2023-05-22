﻿using System.Collections.Generic;

namespace MedApp.Models.Entities
{
    public class Cabinet
    {
        /// <summary>
        /// Id of the cabinet
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Transaction> OldCabinets { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Transaction> NewCabinets { get; set; }
    }
}
