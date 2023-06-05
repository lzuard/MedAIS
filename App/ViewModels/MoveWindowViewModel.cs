using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedApp.Views;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class MoveWindowViewModel : ViewModelBase
    {
        /*------------------------------------------------------------Private properties------------------*/
        private readonly IMessageService _messageService;
        private readonly IAuthService _authService;
        private MoveWindow _window;
        private Hospitalization _currentHospitalization;
        /*Private properties------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Binding properties------------------*/

        #region IsStateTransaction

        private bool _isStateTransaction = true;

        public bool IsStateTransaction
        {
            get => _isStateTransaction;
            set => Set(ref _isStateTransaction, value);
        }

        #endregion IsStateTransaction

        #region SwitchButtonContent

        private string _switchButtonContent= "Выписка";

        public string SwitchButtonContent
        {
            get => _switchButtonContent;
            set => Set(ref _switchButtonContent, value);
        }

        #endregion SwitchButtonContent

        #region CurrentToTabIndex

        private int _currentToTabIndex = 0;

        public int CurrentToTabIndex
        {
            get => _currentToTabIndex;
            set => Set(ref _currentToTabIndex, value);
        }

        #endregion CurrentToTabIndex

        #region MainDiagnosis

        private Diagnosis _mainDiagnosis;

        public Diagnosis MainDiagnosis
        {
            get => _mainDiagnosis;
            set => Set(ref _mainDiagnosis, value);
        }

        #endregion MainDiagnosis



        #region Spor

        private string _spor;

        public string Spor
        {
            get => _spor;
            set => Set(ref _spor, value);
        }

        #endregion Spor


        #region FromDepartmentList

        private IEnumerable<Department> _fromDepartmentList;

        public IEnumerable<Department> FromDepartmentList
        {
            get => _fromDepartmentList;
            set => Set(ref _fromDepartmentList, value);
        }

        #endregion FromDepartmentList

        #region FromUserList

        private IEnumerable<User> _fromUserList;

        public IEnumerable<User> FromUserList
        {
            get => _fromUserList;
            set => Set(ref _fromUserList, value);
        }

        #endregion FromUserList

        #region FromChamberList

        private IEnumerable<Chamber> _fromChamberList;

        public IEnumerable<Chamber> FromChamberList
        {
            get => _fromChamberList;
            set => Set(ref _fromChamberList, value);
        }

        #endregion FromChamberList


        #region ToDepartmentList

        private IEnumerable<Department> _toDepartmentList;

        public IEnumerable<Department> ToDepartmentList
        {
            get => _toDepartmentList;
            set => Set(ref _toDepartmentList, value);
        }

        #endregion ToDepartmentList

        #region ToUserList

        private IEnumerable<User> _toUserList;

        public IEnumerable<User> ToUserList
        {
            get => _toUserList;
            set => Set(ref _toUserList, value);
        }

        #endregion ToUserList

        #region ToChamberList

        private IEnumerable<Chamber> _toChamberList;

        public IEnumerable<Chamber> ToChamberList
        {
            get => _toChamberList;
            set => Set(ref _toChamberList, value);
        }

        #endregion ToChamberList

        #region ToDepartmentSelectedIndex

        private int _toDepartmentSelectedIndex;

        public int ToDepartmentSelectedIndex
        {
            get => _toDepartmentSelectedIndex;
            set => Set(ref _toDepartmentSelectedIndex, value);
        }

        #endregion ToDepartmentSelectedIndex

        #region ToUserSelectedIndex

        private int _toUserSelectedIndex;

        public int ToUserSelectedIndex
        {
            get => _toUserSelectedIndex;
            set => Set(ref _toUserSelectedIndex, value);
        }

        #endregion ToUserSelctedIndex

        #region ToChamberSelectedIndex

        private int _toChamberSelectedIndex;

        public int ToChamberSelectedIndex
        {
            get => _toChamberSelectedIndex;
            set => Set(ref _toChamberSelectedIndex, value);
        }

        #endregion ToChamberSelectedIndex


        #region IsExtractSelected

        private bool _isExtractSelected;

        public bool IsExtractSelected
        {
            get => _isExtractSelected;
            set => Set(ref _isExtractSelected, value);
        }

        #endregion IsExtractSelected

        #region IsDenySelected

        private bool _isDenySelected;

        public bool IsDenySelected
        {
            get => _isDenySelected;
            set => Set(ref _isDenySelected, value);
        }

        #endregion IfDenySelcted

        #region IsDeathSelected

        private bool _isDeathSelected;

        public bool IsDeathSelected
        {
            get => _isDeathSelected;
            set => Set(ref _isDeathSelected, value);
        }

        #endregion IsDeathSelected

        /*Binding properties------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Commands------------------*/

        #region Close command

        private ICommand _closeCommand;

        public ICommand CloseCommand => _closeCommand
            ??= new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);

        private bool CanCloseCommandExecute() => true;

        private void OnCloseCommandExecuted()
        {
            CloseWindow(false);
        }

        #endregion Close

        #region Switch command

        private ICommand _switchCommand;

        public ICommand SwitchCommand => _switchCommand
            ??= new LambdaCommand(OnSwitchCommandExecuted, CanSwitchCommandExecute);

        private bool CanSwitchCommandExecute() => true;

        private void OnSwitchCommandExecuted()
        {
            SwitchState();
        }

        #endregion Switch

        #region Save command

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);

        private bool CanSaveCommandExecute() => true;

        private void OnSaveCommandExecuted()
        {
            SaveData();
        }

        #endregion Save

        /*Commands------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Commands methods------------------*/
        private void CloseWindow(bool quiet)
        {
            if (!quiet)
            {
                var result =
                    _messageService.ShowQuestion("Вы уверены, что хотите выйти? Все несохраненные данные будут утеряны",
                        "Вы уверены?");
                if (result!=MessageBoxResult.Yes) return;
            }
            _window.Close();
        }

        private void SwitchState()
        {
            IsStateTransaction = !IsStateTransaction;
            SwitchButtonContent = IsStateTransaction ? "Выписка" : "Перевод";
            CurrentToTabIndex = IsStateTransaction ? 0 : 1;
        }

        private void SaveData()
        {

        }

        /*Commands methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Private methods------------------*/
        private void InitData()
        {
            FromUserList = new List<User>().Append(_authService.CurrentUser)!;
            FromDepartmentList = new List<Department>().Append(_authService.CurrentUser!.Department);
            FromChamberList = new List<Chamber>().Append(_currentHospitalization.Chamber);
            MainDiagnosis = _currentHospitalization.Diagnosis.FirstOrDefault(d => d.IsMain) ?? new Diagnosis();
        }

        /*Private methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Public methods------------------*/
        public void OpenWindow(MoveWindow window, Hospitalization hospitalization)
        {
            _window = window;
            _currentHospitalization = hospitalization;
            InitData();
        }

        /*Public methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Ctor------------------*/
        public MoveWindowViewModel(IMessageService messageService, IAuthService authService)
        {
            _messageService = messageService;
            _authService = authService;
        }
        /*Ctor------------------------------------------------------------------------------*/
    }
}
