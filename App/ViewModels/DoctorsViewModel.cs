using MathCore.WPF.Commands;
using MedApp.Services;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class DoctorsViewModel : ViewModelBase
    {
        private MainWindowViewModel? _mainWindow;
        private IAuthService _authService;

        private User? _curentUser;

        public User CurentUser
        {
            get => _curentUser;
            set => Set(ref _curentUser, value);
        }

        private string? _username;
        public string UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private string? _userPosition;
        public string UserPosition
        {
            get => _userPosition; 
            set => Set(ref _userPosition, value);
        }

        #region Commands
        #region LogOut command
        private ICommand _logOutCommand;

        public ICommand LogOutCommand => _logOutCommand
            ??= new LambdaCommand(OnLogOutCommandExecuted, CanLogOutCommandExecute);


        private bool CanLogOutCommandExecute() => true;

        private void OnLogOutCommandExecuted()
        {
            _authService.LogOut();
            _mainWindow.SetCurentViewModel(0);
        }
        #endregion
        #endregion

        public void Activate(MainWindowViewModel mainWindowViewModel, IAuthService authService)
        {
            _mainWindow = mainWindowViewModel;
            _authService = authService;
            //Debug
            //authService.LogIn("adminUser", "adminUser");

            _curentUser = _authService.CurrentUser;

            _username = $"{_curentUser.Surname} {_curentUser.Name[0]}. {_curentUser.Patronymic[0]}.";

            _userPosition = _curentUser.Position.Name;
        }
    }
}
