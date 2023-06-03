using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedApp.Views;
using MedData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedApp.ViewModels
{
    internal class ExaminationWindowViewModel : ViewModelBase
    {
        /*------------------------------------------------------------Private properties------------------*/
        private readonly IMessageService _messageService;
        private readonly IExaminationsService _examinationsService;
        private ExaminationWindow? _currentWindow;
        private bool _isNewExamination;
        private int _hospitalizationId;
        /*Private properties------------------------------------------------------------------------------*/

        /*------------------------------------------------------------Binding properties------------------*/
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
            set
            {
                Set(ref _selectedDepartmentIndex, value);
                if (value > -1)
                {
                    UpdateLists(value);
                    SetVisible(true);
                }
                else
                {
                    SetVisible(false);
                }
            }
        }

        #endregion SelectedDepartmentIndex

        #region DoctorVisibility

        private Visibility _doctorVisibility;

        public Visibility DoctorVisibility
        {
            get => _doctorVisibility;
            set => Set(ref _doctorVisibility, value);
        }

        #endregion DoctorVisbility

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

        #region CabinetsVisibility

        private Visibility _cabinetsVisibility;

        public Visibility CabinetsVisibility
        {
            get => _cabinetsVisibility;
            set => Set(ref _cabinetsVisibility, value);
        }

        #endregion CabinetsVisbility

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

        #region ExaminationTypesList

        private IEnumerable<ExaminationType> _examinationTypesList;

        public IEnumerable<ExaminationType> ExaminationTypesList
        {
            get => _examinationTypesList;
            set => Set(ref _examinationTypesList, value);
        }

        #endregion ExaminationTypesList

        #region SelectedExaminationIndex

        private int _selectedExaminationIndex;

        public int SelectedExaminationIndex
        {
            get => _selectedExaminationIndex;
            set => Set(ref _selectedExaminationIndex, value);
        }

        #endregion SelectedExaminationIndex

        #region ExaminationTypeVisibility

        private Visibility _examinationTypeVisibility;

        public Visibility ExaminationTypeVisibility
        {
            get => _examinationTypeVisibility;
            set => Set(ref _examinationTypeVisibility, value);
        }

        #endregion ExaminationTypeVisibility

        /*------------------------------------------------------------Commands------------------*/

        #region Save command

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);

        private bool CanSaveCommandExecute() => true;

        private void OnSaveCommandExecuted()
        {
            SaveData();
        }

        #endregion Save

        #region Close command

        private ICommand _closeCommand;

        public ICommand CloseCommand => _closeCommand
            ??= new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);

        private bool CanCloseCommandExecute() => true;

        private void OnCloseCommandExecuted()
        {
            CloseWindow(false);
        }

        #endregion Close

        /*Commands------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Commands methods------------------*/

        private void CloseWindow(bool quiet)
        {
            var empty = string.IsNullOrEmpty(CurrentExamination.Result);
            if (!(quiet || empty)) // if quiet - do not care if not empty. But if not quiet ask if not empty (statement true when both q and e false)
            {
                var answer = _messageService.ShowQuestion("Вы уверены? Все несохраненные данные будут утеряны.",
                    "Вы уверены?");
                if (answer != MessageBoxResult.Yes) return;
            }
            CurrentExamination = null;
            _currentWindow?.Close();
        }

        private void SaveData()
        {
            CurrentExamination.Cabinet = CabinetsList.ElementAt(SelectedCabinetIndex);
            CurrentExamination.User = DoctorsList.ElementAt(SelectedDoctorIndex);
            CurrentExamination.ExaminationType = ExaminationTypesList.ElementAt(SelectedExaminationIndex);

            var saved = _isNewExamination
                ? _examinationsService.SaveNewExamination(CurrentExamination, _hospitalizationId)
                : _examinationsService.SaveOldExamination(CurrentExamination);

            if (saved) 
                CloseWindow(true);
            else
                _messageService.ShowError("Ошибка сохранения данных", "Ошибка");

        }



        /*Commands methods------------------------------------------------------------------------------*/

        /*Binding properties------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Private methods------------------*/

        private void UpdateLists(int index)
        {
            DoctorsList = _examinationsService.GetDoctorsList(DepartmentsList.ElementAt(index).Id);
            CabinetsList = _examinationsService.GetCabinetsList(DepartmentsList.ElementAt(index).Id);
        }

        private void SetVisible(bool visible)
        {
            if (visible)
            {
                DoctorVisibility = Visibility.Visible;
                CabinetsVisibility = Visibility.Visible;
                ExaminationTypeVisibility = Visibility.Visible;
            }
            else
            {
                DoctorVisibility = Visibility.Hidden;
                CabinetsVisibility = Visibility.Hidden;
                ExaminationTypeVisibility = Visibility.Hidden;
            }
        }

        private void UpdateView()
        {
            SelectedDepartmentIndex = DepartmentsList.FirstIndexOf(CurrentExamination.Cabinet.Department);
            SelectedDoctorIndex = DoctorsList.FirstIndexOf(CurrentExamination.User);
            SelectedCabinetIndex = CabinetsList.FirstIndexOf(CurrentExamination.Cabinet);
            SelectedExaminationIndex = ExaminationTypesList.FirstIndexOf(CurrentExamination.ExaminationType);
        }

        /*Private methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Public methods------------------*/

        public void OpenExistingExamination(ExaminationWindow currentWindow, Examination examination)
        {
            _currentWindow = currentWindow;
            _isNewExamination = false;
            CurrentExamination = examination;
            UpdateView();
        }

        public void OpenNewExamination(ExaminationWindow currentWindow, int hospitalizationId)
        {
            _currentWindow = currentWindow;
            _isNewExamination = true;
            CurrentExamination = new Examination();
            _hospitalizationId=hospitalizationId;
            SelectedDepartmentIndex = -1;
        }

        /*Public methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Ctor------------------*/
        public ExaminationWindowViewModel(
            IMessageService messageService,
            IExaminationsService examinationsService)
        {
            _messageService = messageService;
            _examinationsService = examinationsService;
            DepartmentsList = _examinationsService.GetDepartmentsList().Skip(1);
            ExaminationTypesList = _examinationsService.GetExaminationTypes();
        }
        /*Ctor------------------------------------------------------------------------------*/

    }
}
