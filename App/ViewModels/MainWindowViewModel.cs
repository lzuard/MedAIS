using MathCore.WPF.Commands;
using MedApp.Data;
using MedApp.Services;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly AuthViewModel _authViewModel;
        private readonly DoctorsViewModel _doctorsViewModel;

        public IAuthService AuthService { get => _authService; }

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

        #endregion

        /// <summary>
        /// Changes curent view on MainWindow
        /// 0 - Auth View;
        /// 1 - Doctors View;
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
                    _doctorsViewModel.Activate(this, _authService);
                    CurrentViewModel = _doctorsViewModel;
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public MainWindowViewModel(IAuthService authService, AuthViewModel authViewModel, DoctorsViewModel doctorsViewModel)
        {
            _authService = authService;
            _authViewModel = authViewModel;
            _doctorsViewModel = doctorsViewModel;
           
            SetCurentViewModel(0);
        }

    }
}
