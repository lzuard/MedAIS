using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class AdminViewModel :ViewModelBase
    {
        private MainWindowViewModel _mainWindow;
        private IAuthService _authService;
        private IEntitiesCollectionProvider<Department> _departmentProvider;

        #region Properties

        #region UserName
        private string _userName = "Имя Фамилия Отчество - Должность";
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }
        #endregion

        private IEnumerable<Department> _departments;
        public IEnumerable<Department> Departments
        {
            get=> _departments;
            set=> Set(ref _departments, value);
        }
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
        #region SaveData
        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);


        private bool CanSaveCommandExecute() => true;

        private void OnSaveCommandExecuted()
        {

            bool saved = _departmentProvider.WriteValues(Departments);
            if (saved) 
                MessageBox.Show("Данные сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            else
                MessageBox.Show("Данные не были сохранены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion

        #region UpdateData
        private ICommand _updateCommand;

        public ICommand UpdateCommand => _updateCommand
            ??= new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);


        private bool CanUpdateCommandExecute() => true;

        private void OnUpdateCommandExecuted()
        {
            Departments = _departmentProvider.GetValues();
        }
        #endregion
        #endregion Commands

        public void Activate(MainWindowViewModel mainWindowViewModel, 
            IAuthService authService, 
            IEntitiesCollectionProvider<Department> departmentProvider)
        {
            _departmentProvider = departmentProvider;

            _mainWindow = mainWindowViewModel;
            _authService = authService;

            _userName = _authService.CurrentUser.GetNameAndPosition();

            _departments = _departmentProvider.GetValues();
        }
    }
}
