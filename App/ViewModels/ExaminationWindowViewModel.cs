using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedApp.ViewModels.Base;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class ExaminationWindowViewModel : ViewModelBase
    {
        #region CurrentExamination

        private Examination _currentExamination;

        public Examination CurrentExamination
        {
            get => _currentExamination;
            set => Set(ref _currentExamination, value);
        }

        #endregion CurrentExamination

        #region DepartmentsList

        private IEnumerable<Department> _departmentsList;

        public IEnumerable<Department> DepartmentsList
        {
            get => _departmentsList;
            set => Set(ref _departmentsList, value);
        }

        #endregion DepartmentsList

        #region SelectedDepartmentIndex

        private int _selectedDepartmentIndex;

        public int SelectedDepartmentIndex
        {
            get => _selectedDepartmentIndex;
            set => Set(ref _selectedDepartmentIndex, value);
        }

        #endregion SelectedDepartmentIndex

        #region DoctorsList

        private IEnumerable<User> _doctorsList;

        public IEnumerable<User> DoctorsList
        {
            get => _doctorsList;
            set => Set(ref _doctorsList, value);
        }

        #endregion DoctorsList

        #region SelectedDoctorIndex

        private int _selectedDoctorIndex;

        public int SelectedDoctorIndex
        {
            get => _selectedDoctorIndex;
            set => Set(ref _selectedDoctorIndex, value);
        }

        #endregion SelectedDoctorIndex

        #region CabinetsList

        private IEnumerable<Cabinet> _cabinetsList;

        public IEnumerable<Cabinet> CabinetsList
        {
            get => _cabinetsList;
            set => Set(ref _cabinetsList, value);
        }

        #endregion CabinetsList

        #region SelectedCabinetIndex

        private int _selectedCabinetIndex;

        public int SelectedCabinetIndex
        {
            get => _selectedCabinetIndex;
            set => Set(ref _selectedCabinetIndex, value);
        }

        #endregion SelectedCabinetIndex
    }
}
