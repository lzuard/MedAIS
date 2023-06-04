using System;
using System.Collections.Generic;
using System.Linq;
using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Interfaces;

namespace MedApp.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IRepository<Mkb> _mkbRepo;
        private readonly IRepository<Diagnosis> _diagnosisRepo;

        /// <summary>
        /// Get list of all mkb entities
        /// </summary>
        public IEnumerable<Mkb> GetMkbList() => _mkbRepo.Items.ToList();

        /// <summary>
        /// Get list of all patient diagnosis
        /// </summary>
        public IEnumerable<Diagnosis> GetDiagnosisList(int hospitalizationId) =>
            _diagnosisRepo.Items.Where(d => d.HospitalizationId == hospitalizationId);

        /// <summary>
        /// Save changes in diagnosis
        /// </summary>
        public bool SaveChanges(IEnumerable<Diagnosis> diagnosisList, Hospitalization hospitalization)
        {
            try
            {
                var curDate = DateTime.Now.ToUniversalTime();
                foreach (var diagnosis in diagnosisList)
                {
                    if (diagnosis.Id == 0)
                    {
                        diagnosis.Hospitalization = hospitalization;
                        diagnosis.Date = curDate;
                        _diagnosisRepo.Add(diagnosis);
                    }
                    else
                        _diagnosisRepo.Update(diagnosis);
                }

                _diagnosisRepo.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DiagnosisService(IRepository<Mkb> mkbRepo, IRepository<Diagnosis> diagnosisRepo)
        {
            _mkbRepo = mkbRepo;
            _diagnosisRepo = diagnosisRepo;
        }
    }
}
