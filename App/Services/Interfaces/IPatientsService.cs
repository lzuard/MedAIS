using MedData.Entities;
using System.Collections.Generic;
using MedData;

namespace MedApp.Services.Interfaces
{
    public interface IPatientsService
    {

        public IEnumerable<MedCard> GetAllMedCards();

        public IEnumerable<MedCard> GetDoctorsMedCards(int doctorId);

        public IEnumerable<Hospitalization> GetHospitalizations(int medCardId);

        public Hospitalization GetCurrentHospitalization(int medCardId);

        public IEnumerable<Chamber> GetDoctorsChambers(int doctorId, Gender patientGender);

        public bool SaveNewPatient(MedCard newPatient, Address newAddress, Hospitalization newHospitalization, AnamnesisVitae newAnamnesisVitae, Chamber oldChamber);
       
    }
}
