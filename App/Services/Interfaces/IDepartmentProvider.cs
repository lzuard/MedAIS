using MedData.Entities;
using MedData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Interfaces
{
    interface IDepartmentProvider
    {
        public IEnumerable<Department> GetValues();

        public bool WriteValues(IEnumerable<Department> value);
    }
}
