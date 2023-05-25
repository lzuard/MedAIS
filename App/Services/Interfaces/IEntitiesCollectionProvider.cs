using MedData.Entities;
using MedData.Entities.Base;
using MedData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Interfaces
{
    interface IEntitiesCollectionProvider<T> where T : Entity
    {
        public IEnumerable<T> GetValues();

        public bool WriteValues(IEnumerable<T> value);
    }
}
