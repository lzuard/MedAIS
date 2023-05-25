using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData.Entities;
using System.Windows;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class DoctorsViewModel : ViewModelBase
    {
        private MainWindowViewModel? _mainWindow;
        private IAuthService _authService;

        #region Properties

        #region Current user
        private User? _curentUser;

        public User CurentUser
        {
            get => _curentUser;
            set => Set(ref _curentUser, value);
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
            if (answer == MessageBoxResult.OK)
            {
            _authService.LogOut();
            _mainWindow.SetCurentViewModel(0);
            }
            
        }
        #endregion

        #endregion Commands

        /// <summary>
        /// Need to be called when view is set as a current view in Main Window
        /// </summary>
        public void Activate(MainWindowViewModel mainWindowViewModel, IAuthService authService)
        {
            _mainWindow = mainWindowViewModel;
            _authService = authService;

            _curentUser = _authService.CurrentUser;
            _username = $"{_curentUser.Surname} {_curentUser.Name[0]}. {_curentUser.Patronymic[0]}.";
            _userPosition = _curentUser.Position.Name;
        }
    }
}
