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
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MedApp.ViewModels
{
    internal class AdminViewModel :ViewModelBase
    {
        private MainWindowViewModel _mainWindow;
        private readonly IAuthService _authService;
        private readonly IMessageService _messageService;
        private readonly ICsvImporterService _csvImporterService;
        private readonly IEntitiesCollectionProvider<Department> _departmentProvider;
        private readonly IEntitiesCollectionProvider<Position> _positionProvider;
        private readonly IEntitiesCollectionProvider<User> _userProvider;
        private readonly IEntitiesCollectionProvider<Chamber> _chamberProvider;
        private readonly IEntitiesCollectionProvider<Cabinet> _cabinetProvider;
        private readonly IEntitiesCollectionProvider<Mkb> _mkbProvider;

        #region Properties

        #region UserName
        private string _userName = "Имя Фамилия Отчество - Должность";
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }
        #endregion

        #region Departments
        private IEnumerable<Department> _departments;
        public IEnumerable<Department> Departments
        {
            get=> _departments;
            set=> Set(ref _departments, value);
        }
        #endregion

        #region Positions
        private IEnumerable<Position> _positions;
        public IEnumerable<Position> Positions
        {
            get => _positions;
            set => Set(ref _positions, value);
        }
        #endregion

        #region Users
        private IEnumerable<User> _users;
        public IEnumerable<User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }
        #endregion

        #region Chambers
        private IEnumerable<Chamber> _chambers;
        public IEnumerable<Chamber> Chambers
        {
            get => _chambers;
            set => Set(ref _chambers, value);
        }
        #endregion

        #region Cabinets
        private IEnumerable<Cabinet> _cabinets;
        public IEnumerable<Cabinet> Cabinets
        {
            get => _cabinets;
            set => Set(ref _cabinets, value);
        }
        #endregion

        #region MKBs
        private IEnumerable<Mkb> _mkbs;
        public IEnumerable<Mkb> MKBs
        {
            get => _mkbs;
            set => Set(ref _mkbs, value);
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
        #region SaveData
        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);


        private bool CanSaveCommandExecute() => true;

        private void OnSaveCommandExecuted()
        {

            bool saved = _departmentProvider.WriteValues(Departments);
            saved &= _positionProvider.WriteValues(Positions);
            saved &= _userProvider.WriteValues(Users);
            saved &= _chamberProvider.WriteValues(Chambers);
            saved &= _cabinetProvider.WriteValues(Cabinets);
            saved &= _mkbProvider.WriteValues(MKBs);

            if (saved) 
                _messageService.ShowNotification("Данные сохранены", "Успех");
            else
                _messageService.ShowError("Данные не были сохранены", "Ошибка");
        }
        #endregion
        #region UpdateData
        private ICommand _updateCommand;

        public ICommand UpdateCommand => _updateCommand
            ??= new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);


        private bool CanUpdateCommandExecute() => true;

        private void OnUpdateCommandExecuted()
        {
           UpdateData();
        }
        #endregion

        #region ImportMkb command

        private ICommand _importMkbCommand;

        public ICommand ImportMkbCommand => _importMkbCommand
            ??= new LambdaCommand(OnImportMkbCommandExecuted, CanImportMkbCommandExecute);

        private bool CanImportMkbCommandExecute() => true;

        private void OnImportMkbCommandExecuted()
        {
            ImportMkb();
        }

        #endregion ImportMkb
        #endregion Commands

        private void ImportMkb()
        {
            var filepath = _messageService.ShowFilePicker("Файл CSV", "|*.csv");

            var imported = _csvImporterService.LoadMkb(filepath);

            if (imported)
            {
                _messageService.ShowNotification("Файл загружен успешно","Успех");
                UpdateData();
            }
            else
            {
                _messageService.ShowError("Ошибка загрузки файла", "Ошибка");
            }
        }

        private void UpdateData()
        {
            _departments = _departmentProvider.GetValues();
            _positions = _positionProvider.GetValues();
            _users = _userProvider.GetValues();
            _chambers = _chamberProvider.GetValues();
            _cabinets = _cabinetProvider.GetValues();
            _mkbs = _mkbProvider.GetValues();
        }

        public void Activate(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
            _userName = _authService.CurrentUser.GetNameAndPosition();
            UpdateData();
        }

        public AdminViewModel(
            IAuthService authService,
            IMessageService messageService,
            ICsvImporterService csvImporterService,
            IEntitiesCollectionProvider<Department> departmentProvider,
            IEntitiesCollectionProvider<Position> positionProvider,
            IEntitiesCollectionProvider<User> userProvider,
            IEntitiesCollectionProvider<Chamber> chambersProvider,
            IEntitiesCollectionProvider<Cabinet> cabinetProvider,
            IEntitiesCollectionProvider<Mkb> mkbProvider)
        {
            _departmentProvider = departmentProvider;
            _positionProvider = positionProvider;
            _userProvider = userProvider;
            _chamberProvider = chambersProvider;
            _cabinetProvider = cabinetProvider;
            _mkbProvider = mkbProvider;
            _authService = authService;
            _messageService = messageService;
            _csvImporterService = csvImporterService;
        }
    }
}
