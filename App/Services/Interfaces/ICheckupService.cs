using MedData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Interfaces
{
    public interface ICheckupService
    {

        public bool SaveNewCheckup(Checkup checkup, int hospitalizationId);

        public bool SaveOldCheckup(Checkup checkup);

        public IEnumerable<Checkup>? GetPatientCheckups(int hospitalizationId);
    }
}
