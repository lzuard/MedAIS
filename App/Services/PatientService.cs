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

        /// <summary>
        /// Returns all medcards from the database
        /// </summary>
        public IEnumerable<MedCard> GetAllMedCards() => 
            _medCardRepo.Items.ToList();


        /// <summary>
        /// Save new patient in the database
        /// </summary>
        public bool SaveNewPatient(MedCard newPatient, Address newAddress)
        {
            try
            {
                var savedAddress = _addressRepo.Add(newAddress);
                newPatient.Address = savedAddress;
                if (newPatient != _medCardRepo.Add(newPatient))
                    throw new Exception();
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
                //Get all patient in chambers objects for the doctor
                IEnumerable<PatientInChamber> doctorsChambers = _medCardRepo.Items.SelectMany(c => c.PatientInChambers)
                    .Where(c => c.Chamber.UserId == doctorId);

                //Get all chambers for patient gender
                IEnumerable<Chamber> availableChambers = doctorsChambers.Select(c => c.Chamber)
                    .Where(c=>c.Gender == patientGender)
                    .Distinct();

                return availableChambers;
            }
            catch
            {
                return null;
            }
        }

        public PatientService(IRepository<MedCard> medCardRepo, IRepository<Address> addressRepo)
        {
            _medCardRepo = medCardRepo;
            _addressRepo = addressRepo;
        }
    }
}
