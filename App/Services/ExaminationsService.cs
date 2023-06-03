using System.Linq;
using MedData.Entities;
using MedData.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedApp.Services.Interfaces
{
    public class ExaminationsService: IExaminationsService
    {
        private readonly IRepository<Examination> _examinationRepo;
        private readonly IRepository<Department> _departmentRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Cabinet> _cabinetRepository;
        private readonly IRepository<ExaminationType> _examinationTypeRepo;
        private readonly IRepository<Hospitalization> _hospitalizationRepo;

        public IEnumerable<Examination> GetExaminations(int hospitalizationId) =>
            _examinationRepo.Items.Where(e => e.HospitalizationId == hospitalizationId);

        /// <summary>
        /// Get list of departments
        /// </summary>
        public IEnumerable<Department> GetDepartmentsList() => 
            _departmentRepo.Items.ToList();

        /// <summary>
        /// Get list of possible examinations
        /// </summary>
        public IEnumerable<ExaminationType> GetExaminationTypes() =>
            _examinationTypeRepo.Items.ToList();

        /// <summary>
        /// Get doctors of specified department
        /// </summary>
        public IEnumerable<User> GetDoctorsList(int departmentId) => 
            _userRepo.Items.Where(u => u.DepartmentId == departmentId).ToList();

        /// <summary>
        /// Get list of cabinets of specified department
        /// </summary>
        public IEnumerable<Cabinet> GetCabinetsList(int departmentId) =>
            _cabinetRepository.Items.Where(c => c.DepartmentId == departmentId).ToList();

        /// <summary>
        /// Save new examination entity
        /// </summary>
        public bool SaveNewExamination(Examination examination, int hospitalizationId)
        {
            try
            {
                examination.Hospitalization = _hospitalizationRepo.Items.FirstOrDefault(h => h.Id == hospitalizationId);
                _examinationRepo.Add(examination);
                _examinationRepo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Save existing examination entity
        /// </summary>
        public bool SaveOldExamination(Examination examination)
        {
            try
            {
                _examinationRepo.Update(examination);
                _examinationRepo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ExaminationsService(
            IRepository<Examination> examinationRepo,
            IRepository<Department> departmentRepo,
            IRepository<User> userRepo,
            IRepository<Cabinet> cabinetRepository,
            IRepository<ExaminationType> examinationTypeRepo,
            IRepository<Hospitalization> hospitalizationRepo)
        {
            _examinationRepo = examinationRepo;
            _departmentRepo = departmentRepo;
            _userRepo = userRepo;
            _cabinetRepository = cabinetRepository;
            _examinationTypeRepo = examinationTypeRepo;
            _hospitalizationRepo = hospitalizationRepo;
        }
    }
}
