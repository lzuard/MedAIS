using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedData.Entities.Base;

namespace MedData.Entities
{
    public class ExaminationType : Entity
    {

        /// <summary>
        /// Actual name of the examination
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// EF navigation property
        /// </summary>
        public ICollection<Examination> Examinations { get; set; }

        public override string ToString() => Name;
    }
}
