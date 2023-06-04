using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedData.Entities;

namespace MedApp.Services.Interfaces
{
    public interface IDiagnosisService
    {
        public IEnumerable<Mkb> GetMkbList();

        public IEnumerable<Diagnosis> GetDiagnosisList(int hospitalizationId);

        public bool SaveChanges(IEnumerable<Diagnosis> diagnosisList, Hospitalization hospitalization);
    }
}
