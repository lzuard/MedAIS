using MedData.Entities;
using System.Linq;
using MedData.Interfaces;
using System.Collections.Generic;

namespace MedApp.Services.Interfaces
{
    public class CheckupService : ICheckupService
    {
        private readonly IRepository<Checkup> _checkupRepo;
        private readonly IRepository<Hospitalization> _hospitalizationRepo;

        /// <summary>
        /// Saves new checkup entity
        /// </summary>
        public bool SaveNewCheckup(Checkup checkup, int hospitalizationId)
        {
            try
            {
                var hospitalization = _hospitalizationRepo.Items.FirstOrDefault(h => h.Id == hospitalizationId);

                checkup.Hospitalization = hospitalization;

                //Add checkup entity
                var savedCheckup = _checkupRepo.Add(checkup);

                _checkupRepo.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Updates old checkup entity
        /// </summary>
        public bool SaveOldCheckup(Checkup checkup)
        {
            try
            {
                _checkupRepo.Update(checkup);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns list of "Checkup" entities for hospitalization
        /// </summary>
        public IEnumerable<Checkup>? GetPatientCheckups(int hospitalizationId)
        {
            try
            {
                var checkups = _hospitalizationRepo.Items.SelectMany(h => h.Checkups)
                    .Where(c => c.HospitalizationId == hospitalizationId);
                return checkups;
            }
            catch
            {
                return null;
            }
        }

        public CheckupService(IRepository<Checkup> checkupRepo, IRepository<Hospitalization> hospitalizationRepo)
        {
            _checkupRepo = checkupRepo;
            _hospitalizationRepo = hospitalizationRepo;
        }
    }
}
