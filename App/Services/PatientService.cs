using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MedData;

namespace MedApp.Services
{
    public class PatientService : IPatientsService
    {
        private readonly IRepository<MedCard> _medCardRepo;
        private readonly IRepository<Address> _addressRepo;
        private readonly IRepository<AnamnesisVitae> _anamnesisRepo;
        private readonly IRepository<Hospitalization> _hospitalizationRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<PatientInChamber> _patientInChamberRepo;

        /// <summary>
        /// Returns all medcards from the database
        /// </summary>
        public IEnumerable<MedCard> GetAllMedCards() => 
            _medCardRepo.Items.ToList();


        /// <summary>
        /// Save new patient in the database
        /// </summary>
        public bool SaveNewPatient(MedCard newPatient,
            Address newAddress,
            Hospitalization newHospitalization,
            AnamnesisVitae newAnamnesisVitae,
            Chamber oldChamber)
        {
            try
            {
                //Save new address object
                var savedAddress = _addressRepo.Add(newAddress);

                //Save new anamnesis vitae object
                var savedAnamnesisVitae = _anamnesisRepo.Add(newAnamnesisVitae);

                //Add anamnesis vitae to new hospitalization
                newHospitalization.AnamnesisVitae = savedAnamnesisVitae;

                //Set isActive property for hospitalization true
                newHospitalization.IsActive = true;

                //Save new hospitalization object
                var savedHospitalization = _hospitalizationRepo.Add(newHospitalization);

                //Add address to new medcard object
                newPatient.Address = savedAddress;

                //Add hospitalization to new medcard object
                newPatient.Hospitalizations = new List<Hospitalization>{ savedHospitalization };

                //Add new medcard object
                if (newPatient != _medCardRepo.Add(newPatient))
                    throw new Exception();

                //Create new Patient In Chamber object to connect patient and chamber
                var newPatientInChamber = new PatientInChamber()
                {
                     MedCard = newPatient,
                     Chamber = oldChamber
                };

                //Save new patient in chamber object
                var savedPatientInChamber = _patientInChamberRepo.Add(newPatientInChamber);

                //Save changes
                _medCardRepo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        } 

        /// <summary>
        /// Returns all active doctors patients 
        /// </summary>
        public IEnumerable<MedCard> GetDoctorsMedCards(int doctorId)
        {
            try
            {
                var doctorsMedcards = _medCardRepo.Items
                    .Where(i => i.PatientInChambers.Any(j => j.Chamber.UserId == doctorId) &&
                                i.Hospitalizations.Any(h => h.IsActive))
                    .ToList();
                return doctorsMedcards;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns all patients hospitalizations
        /// </summary>
        public IEnumerable<Hospitalization> GetHospitalizations(int medCardId)
        {
            try
            {
                var hospitalizations = _medCardRepo.Items
                    .SelectMany(medcard => medcard.Hospitalizations)
                    .Where(medcard => medcard.Id == medCardId)
                    .ToList();
                return hospitalizations;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns one active patients hospitalization
        /// </summary>
        public Hospitalization GetCurrentHospitalization(int medCardId)
        {
            var hospitalizations = GetHospitalizations(medCardId);
            Hospitalization? hospitalization = null;

            if (hospitalizations is not null)
                hospitalization = hospitalizations.FirstOrDefault(h => h.IsActive);

            return hospitalization;
        }

        /// <summary>
        /// Returns all doctors chambers with specified gender
        /// </summary>
        public IEnumerable<Chamber> GetDoctorsChambers(int doctorId, Gender patientGender)
        {
            try
            {
                IEnumerable<Chamber> availableChambers =
                    _userRepo.Items.SelectMany(u => u.Chambers).Where(c => c.Gender == patientGender).ToList();

                ////Get all patient in chambers objects for the doctor
                //IEnumerable<PatientInChamber> doctorsChambers = _medCardRepo.Items.SelectMany(c => c.PatientInChambers)
                //    .Where(c => c.Chamber.UserId == doctorId);

                ////Get all chambers for patient gender
                //IEnumerable<Chamber> availableChambers = doctorsChambers.Select(c => c.Chamber)
                //    .Where(c=>c.Gender == patientGender)
                //    .Distinct();

                return availableChambers;
            }
            catch
            {
                return null;
            }
        }

        public PatientService(IRepository<MedCard> medCardRepo,
            IRepository<Address> addressRepo,
            IRepository<AnamnesisVitae> anamnesisRepo,
            IRepository<Hospitalization> hospitalizationRepo,
            IRepository<User> userRepo,
            IRepository<PatientInChamber> patientInChamberRepo)
        {
            _medCardRepo = medCardRepo;
            _addressRepo = addressRepo;
            _anamnesisRepo = anamnesisRepo;
            _hospitalizationRepo = hospitalizationRepo;
            _userRepo = userRepo;
            _patientInChamberRepo = patientInChamberRepo;
        }
    }
}
