﻿using MedApp.Services.Interfaces;
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
                newHospitalization.Treatments = new List<Treatment>();
                newHospitalization.Chamber = oldChamber;

                //Set isActive property for hospitalization true
                newHospitalization.IsActive = true;

                //TODO: change the way new patient saves

                //Save new hospitalization object
                var savedHospitalization = _hospitalizationRepo.Add(newHospitalization);

                //Add address to new medcard object
                newPatient.Address = savedAddress;

                //Add hospitalization to new medcard object
                newPatient.Hospitalizations = new List<Hospitalization>{ savedHospitalization };

                //Add new medcard object
                if (newPatient != _medCardRepo.Add(newPatient))
                    throw new Exception();

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
        /// Saves existing patient information in db
        /// </summary>
        public bool SaveOldPatient(MedCard newPatient,
            Address newAddress,
            Hospitalization newHospitalization,
            AnamnesisVitae newAnamnesisVitae,
            Chamber newChamber,
            IEnumerable<Treatment> newTreatments)
        {
            try
            {
                //TODO: implement treatment saving
                //TODO: changed the order patient in chamber saves
                newHospitalization.Treatments.AddItems(newTreatments.Where(t => t.Id ==0));
                newHospitalization.Chamber = newChamber;

                _hospitalizationRepo.Update(newHospitalization);
                _addressRepo.Update(newAddress);
                _anamnesisRepo.Update(newAnamnesisVitae);
               
                _medCardRepo.Update(newPatient);

                _medCardRepo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Returns anamnesis vitae object by hospitalization id
        /// </summary>
        public AnamnesisVitae GetAnamnesisVitae(int hospitalizationId)
        {
            try
            {
                var anamnesis = _anamnesisRepo.Items.FirstOrDefault(a => a.HospitalizationId == hospitalizationId);
                return anamnesis;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
            /// Returns all active doctors patients 
            /// </summary>
        public IEnumerable<MedCard> GetDoctorsMedCards(int doctorId)
        {
            try
            {
                //TODO: changed the way medcards loads
                var doctorsMedcards = _hospitalizationRepo.Items.Where(h=> h.IsActive && h.Chamber.UserId==doctorId)
                    .Select(h=> h.MedCard).ToList();
                /* var doctorsMedcards = _hospitalizationRepo.Items.Where(h =>
                         h.PatientInChambers.Any(j => j.Chamber.UserId == doctorId) && h.IsActive)
                     .Select(h => h.MedCard).ToList();*/
                //var doctorsMedcards = _medCardRepo.Items
                //    .Where(i => i.PatientInChambers.Any(j => j.Chamber.UserId == doctorId) &&
                //                i.Hospitalizations.Any(h => h.IsActive))
                //    .ToList();
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
                    .Where(medcard => medcard.MedCardId == medCardId)
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

        /// <summary>
        /// Returns all examinations of specified hospitalization
        /// </summary>
        public IEnumerable<Examination> GetExaminations(int hospitalizationId) =>
            _hospitalizationRepo.Items.FirstOrDefault(h => h.Id == hospitalizationId).Examinations.ToList();

        public PatientService(IRepository<MedCard> medCardRepo,
            IRepository<Address> addressRepo,
            IRepository<AnamnesisVitae> anamnesisRepo,
            IRepository<Hospitalization> hospitalizationRepo,
            IRepository<User> userRepo)
        {
            _medCardRepo = medCardRepo;
            _addressRepo = addressRepo;
            _anamnesisRepo = anamnesisRepo;
            _hospitalizationRepo = hospitalizationRepo;
            _userRepo = userRepo;
        }
    }
}
