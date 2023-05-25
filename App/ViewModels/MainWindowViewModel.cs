using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly AuthViewModel _authViewModel;
        private readonly DoctorsViewModel _doctorsViewModel;
        private readonly PatientViewModel _patientViewModel;
        private readonly AdminViewModel _adminViewModel;

        #region Properties

        #region Window Title
        private string _title = "МедАИС - Медицинская автоматизированная система";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion
        #region Curent viewmodel
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        #endregion

        #endregion Properties

        #region Commands

        #region Doctor view command
        private ICommand _doctorViewCommand;

        public ICommand DoctorViewCommand => _doctorViewCommand
            ??= new LambdaCommand(OnDoctorViewCommandExecuted, CanDoctorViewCommandExecute);


        private bool CanDoctorViewCommandExecute() => true;

        private void OnDoctorViewCommandExecuted()
        {
            SetCurentViewModel(1);
        }
        #endregion
        #region Auth view command
        private ICommand _authViewCommand;

        public ICommand AuthViewCommand => _authViewCommand
            ??= new LambdaCommand(OnAuthViewCommandExecuted, CanAuthViewCommandExecute);


        private bool CanAuthViewCommandExecute() => true;

        private void OnAuthViewCommandExecuted()
        {
            SetCurentViewModel(0);
        }
        #endregion

        #endregion Commands

        /// <summary>
        /// Changes curent view on MainWindow: (
        /// 0 - Auth View;
        /// 1 - Doctors View;
        /// )
        /// </summary>
        public void SetCurentViewModel(int number)
        {
            switch (number)
            {
                case 0:
                    _authViewModel.Activate(this, _authService);
                    CurrentViewModel = _authViewModel; 
                    break;
                case 1:
                    _doctorsViewModel.Activate(this, _authService, _patientViewModel);
                    CurrentViewModel = _doctorsViewModel;
                    break;
                case 2:
                    _adminViewModel.Activate(this, _authService);
                    CurrentViewModel = _adminViewModel;
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public MainWindowViewModel(IAuthService authService, 
            AuthViewModel authViewModel, 
            DoctorsViewModel doctorsViewModel,
            PatientViewModel patientViewModel,
            AdminViewModel adminViewModel)
        {
            _authService = authService;
            _authViewModel = authViewModel;
            _doctorsViewModel = doctorsViewModel;
            _patientViewModel = patientViewModel;
            _adminViewModel = adminViewModel;

            //debug
            //_authService.LogIn("1", "1");
            SetCurentViewModel(0);
        }

    }
}
