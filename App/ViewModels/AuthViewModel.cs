using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class AuthViewModel:ViewModelBase
    {
        private MainWindowViewModel? _mainWindow;
        private IAuthService _authService;

        #region Properties

        #region Login
        private string? _login;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        #endregion

        #region Password
        private string? _password;

        public string Password
        {
            get=> _password;
            set => Set(ref _password, value);
        }
        #endregion

        #endregion Properties

        #region Commands
        #region Auth command
        private ICommand _authCommand;

        public ICommand AuthCommand => _authCommand
            ??= new LambdaCommand(OnAuthCommandExecuted, CanAuthCommandExecute);

        private bool CanAuthCommandExecute() => true;

        private void OnAuthCommandExecuted()
        {
            var user = _authService.LogIn(_login, _password);

            if (user != null)
            {
                _login = "";
                _password = "";
                if (user.Department.Name.Contains("IT"))
                    _mainWindow.SetCurentViewModel(2);
                else
                    _mainWindow.SetCurentViewModel(1);
            }

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

        #endregion Commands

        /// <summary>
        /// Need to be called when view is set as a current view in Main Window
        /// </summary>
        public void Activate(MainWindowViewModel mainWindow, IAuthService authService)
        {
            _mainWindow = mainWindow;
            _authService = authService;
        }
    }
}
