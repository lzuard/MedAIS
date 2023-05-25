using MedData.Entities;
using System.Collections.Generic;

namespace MedApp.Services.Interfaces
{
    public interface IPatientsService
    {

        public IEnumerable<MedCard> GetAllMedCards();

        public IEnumerable<MedCard> GetDoctorsMedCards(int doctorId);

        public IEnumerable<Hospitalization> GetHospitalizations(int medCardId);

        public bool SaveNewPatient(MedCard newPatient);
       
    }
}
