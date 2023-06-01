using MedData.Entities;
using System.Collections.Generic;
using MedData;

namespace MedApp.Services.Interfaces
{
    public interface IPatientsService
    {
        /// <summary>
        /// Get list of all medcards
        /// </summary>
        public IEnumerable<MedCard> GetAllMedCards();

        /// <summary>
        /// Get all medcards of specified doctor
        /// </summary>
        /// <param name="doctorId"></param>
        public IEnumerable<MedCard> GetDoctorsMedCards(int doctorId);

        /// <summary>
        /// Get all hospitalizations of specified patient
        /// </summary>
        /// <param name="medCardId"></param>
        public IEnumerable<Hospitalization> GetHospitalizations(int medCardId);

        /// <summary>
        /// Get active hospitalization of specified patient
        /// </summary>
        /// <param name="medCardId"></param>
        /// <returns></returns>
        public Hospitalization GetCurrentHospitalization(int medCardId);

        /// <summary>
        /// Get Anamnesis Vitae of specified hospitalization
        /// </summary>
        /// <param name="hospitalizationId"></param>
        /// <returns></returns>
        public AnamnesisVitae GetAnamnesisVitae(int hospitalizationId);

        /// <summary>
        /// Get list of doctors chambers with specified gender
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="patientGender"></param>
        /// <returns></returns>
        public IEnumerable<Chamber> GetDoctorsChambers(int doctorId, Gender patientGender);

        /// <summary>
        /// Save new medcard entity
        /// </summary>
        public bool SaveNewPatient(MedCard newPatient, Address newAddress, Hospitalization newHospitalization, AnamnesisVitae newAnamnesisVitae, Chamber oldChamber);

        /// <summary>
        /// Update medcard entity
        /// </summary>
        public bool SaveOldPatient(MedCard newPatient, Address newAddress, Hospitalization newHospitalization, AnamnesisVitae newAnamnesisVitae, Chamber newChamber, IEnumerable<Treatment> newTreatments);
    }
}
