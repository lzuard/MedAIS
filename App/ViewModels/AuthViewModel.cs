using MathCore.WPF.Commands;
using MedApp.Services;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class AuthViewModel:ViewModelBase
    {
        private IAuthService _authService;
        private MainWindowViewModel _mainWindow;

        private string? _login;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        private string? _password;

        public string Password
        {
            get=> _password;
            set => Set(ref _password, value);
        }

        #region Auth command
        private ICommand _authCommand;

        public ICommand AuthCommand => _authCommand
            ??= new LambdaCommand(OnAuthCommandExecuted, CanAuthCommandExecute);


        private bool CanAuthCommandExecute() => true;

        private void OnAuthCommandExecuted()
        {
            var user = _authService.LogIn(_login, _password);

            if (user != null)
                _mainWindow.CurrentViewModel = new DoctorsViewModel();

            else
                MessageBox.Show("Неверный пароль и/или логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #region Help command
        private ICommand _helpCommand;

        public ICommand HelpCommand => _helpCommand
            ??= new LambdaCommand(OnHelpCommandExecuted, CanHelpCommandExecute);


        private bool CanHelpCommandExecute() => true;

        private void OnHelpCommandExecuted()
        {
            var helpMessage = "Если у вас проблемы со входом, обратитесь к сотрудникам IT-отдела:\n\n";
            helpMessage += _authService.GetHelp();
            MessageBox.Show(helpMessage,"Помощь",MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion



        public AuthViewModel(IAuthService authService, MainWindowViewModel mainWindow) 
        {
            _authService = authService;
            _mainWindow = mainWindow;
        }
    }
}
