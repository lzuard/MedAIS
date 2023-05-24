using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        private IAuthService _authService;

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

        #endregion

        #region Commands

        #region Doctor view command
        private ICommand _doctorViewCommand;

        public ICommand DoctorViewCommand => _doctorViewCommand
            ??= new LambdaCommand(OnDoctorViewCommandExecuted, CanDoctorViewCommandExecute);


        private bool CanDoctorViewCommandExecute() => true;

        private void OnDoctorViewCommandExecuted()
        {
            CurrentViewModel = new DoctorsViewModel(_authService);
        }
        #endregion
        #region Auth view command
        private ICommand _authViewCommand;

        public ICommand AuthViewCommand => _authViewCommand
            ??= new LambdaCommand(OnAuthViewCommandExecuted, CanAuthViewCommandExecute);


        private bool CanAuthViewCommandExecute() => true;

        private void OnAuthViewCommandExecuted()
        {
            CurrentViewModel = new AuthViewModel(_authService, this);
        }
        #endregion

        #endregion

        public MainWindowViewModel(IAuthService authService)
        {
            _authService = authService;

        }

    }
}
