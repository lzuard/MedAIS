using MathCore.WPF.Commands;
using MedApp.Services;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class DoctorsViewModel : ViewModelBase
    {
        private MainWindowViewModel? _mainWindow;
        private IAuthService _authService;
        private IPatientsService _patientService;
        

        #region Properties

        #region Current user
        private User? _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }
        #endregion

        #region User name
        private string? _username;
        public string UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }
        #endregion

        #region User position
        private string? _userPosition;
        public string UserPosition
        {
            get => _userPosition; 
            set => Set(ref _userPosition, value);
        }
        #endregion

        #region CurrentPatient

        private MedCard? _currentPatient;

        public MedCard? CurrentPatient
        {
            get => _currentPatient;
            set
            {
                Set(ref _currentPatient, value);
                MedCardVisibility = _currentPatient is null ? Visibility.Hidden : Visibility.Visible;
                //UpdatePatientsList();
            }
        }
        #endregion CurrentPatient

        #region MedCardVisibility

        private Visibility _medCardVisibility;

        public Visibility MedCardVisibility
        {
            get => _medCardVisibility;
            set => Set(ref _medCardVisibility, value);
        }

        #endregion MedCardVisibility

        #region PatientViewModel
        private PatientViewModel? _patientViewModel;
        public PatientViewModel? PatientViewModel
        {
            get => _patientViewModel;
            set => Set(ref _patientViewModel, value);
        }
        #endregion

        #region Patients
        private IEnumerable<MedCard> _patients;

        public IEnumerable<MedCard> Patients
        {
            get => _patients;
            set => Set(ref _patients, value);
        }

        #endregion

        #endregion Properties

        #region Commands
        #region LogOut command
        private ICommand _logOutCommand;

        public ICommand LogOutCommand => _logOutCommand
            ??= new LambdaCommand(OnLogOutCommandExecuted, CanLogOutCommandExecute);


        private bool CanLogOutCommandExecute() => true;

        private void OnLogOutCommandExecuted()
        {
            var answer = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход из системы", 
                MessageBoxButton.OKCancel, 
                MessageBoxImage.Question, 
                MessageBoxResult.Cancel);
            if (answer != MessageBoxResult.OK) return;
            _authService.LogOut();
            _mainWindow.SetCurentViewModel(0);

        }
        #endregion

        #region AddNewPatient command

        private ICommand _addNewPatientCommand;

        public ICommand AddNewPatientCommand => _addNewPatientCommand
            ??= new LambdaCommand(OnAddNewPatientCommandExecuted, CanAddNewPatientCommandExecute);

        private bool CanAddNewPatientCommandExecute() => true;

        private void OnAddNewPatientCommandExecuted()
        {
            CurrentPatient = new MedCard();
            _patientViewModel.PopUp(this, _patientService,CurrentPatient, CurrentUser.Id);
        }

        #endregion AddNewPatient
        #endregion Commands

        private void UpdatePatientsList()
        {
            Patients = _patientService.GetDoctorsMedCards(CurrentUser.Id);
        }

        /// <summary>
        /// Need to be called when view is set as a current view in Main Window
        /// </summary>
        public void Activate
            (
            MainWindowViewModel mainWindowViewModel, 
            IAuthService authService, 
            PatientViewModel patientViewModel,
            IPatientsService patientsService)
        {
            _mainWindow = mainWindowViewModel;
            _authService = authService;
            _patientService = patientsService;
            _patientViewModel = patientViewModel;

            CurrentUser = _authService.CurrentUser;
            UserName = $"{_currentUser.Surname} {_currentUser.Name[0]}. {_currentUser.Patronymic[0]}.";
            UserPosition = _currentUser.Position.Name;

            CurrentPatient = null;
            UpdatePatientsList();
        }
    }
}
