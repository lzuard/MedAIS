using MedData.Entities.Base;
using System.Collections.Generic;

namespace MedData.Entities
{
    public class Mkb : Entity
    {
        /// <summary>
        /// Actual MKB-10 code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the diseases
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Diagnosis> DiagnosisCollection { get; set; }

    }
}
