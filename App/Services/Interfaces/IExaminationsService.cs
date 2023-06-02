using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCore.Annotations;
using MedData.Entities;

namespace MedApp.Services.Interfaces
{
    public interface IExaminationsService
    {
        public IEnumerable<Department> GetDepartmentsList();

        public IEnumerable<ExaminationType> GetExaminationTypes();

        public IEnumerable<User> GetDoctorsList(int departmentId);

        public IEnumerable<Cabinet> GetCabinetsList(int departmentId);

        public bool SaveNewExamination(Examination  examination);

        public bool SaveOldExamination(Examination examination);
    }
}
