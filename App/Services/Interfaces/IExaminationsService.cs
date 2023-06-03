using System.Collections.Generic;
using MedData.Entities;

namespace MedApp.Services.Interfaces
{
    public interface IExaminationsService
    {
        public IEnumerable<Examination> GetExaminations(int hospitalizationId);

        public IEnumerable<Department> GetDepartmentsList();

        public IEnumerable<ExaminationType> GetExaminationTypes();

        public IEnumerable<User> GetDoctorsList(int departmentId);

        public IEnumerable<Cabinet> GetCabinetsList(int departmentId);

        public bool SaveNewExamination(Examination  examination, int hospitalizationId);

        public bool SaveOldExamination(Examination examination);
    }
}
