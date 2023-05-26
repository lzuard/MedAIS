using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedApp.Services
{
    public class PatientService : IPatientsService
    {
        private readonly IRepository<MedCard> _medCardRepo;
        private readonly IRepository<Address> _addressRepo;

        public IEnumerable<MedCard> GetAllMedCards() => 
            _medCardRepo.Items.ToList();

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

        public IEnumerable<MedCard> GetDoctorsMedCards(int doctorId)
        {
            try
            {
                var doctorsMedcards = _medCardRepo.Items
                    .Where(i => i.PatientInChambers.Any(j => j.Chamber.UserId == doctorId))
                    .ToList();
                return doctorsMedcards;
            }
            catch
            {
                return null;
            }
        }

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

        public PatientService(IRepository<MedCard> medCardRepo, IRepository<Address> addressRepo)
        {
            _medCardRepo = medCardRepo;
            _addressRepo = addressRepo;
        }
    }
}
