using System.CodeDom;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedApp.Views;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class CheckupWindowViewModel : ViewModelBase
    {
        private readonly ICheckupService _checkupService;
        private readonly IAuthService _authService;
        private Checkup _previousCheckup;
        private CheckupWindow _currentWindow;
        private int _hospitalizationId;
        private int _doctorId;

        #region CurrentCheckup

        private Checkup _currentCheckup;

        public Checkup CurrentCheckup
        {
            get => _currentCheckup;
            set => Set(ref _currentCheckup, value);
        }

        #endregion CurrentCheckup

        #region IsLoadButtonEnabled

        private bool _isLoadButtonEnabled;

        public bool IsLoadButtonEnabled
        {
            get => _isLoadButtonEnabled;
            set => Set(ref _isLoadButtonEnabled, value);
        }

        #endregion IsLoadButtonEnabled

        #region CloseWindow command

        private ICommand _closeWindowCommand;

        public ICommand CloseWindowCommand => _closeWindowCommand
            ??= new LambdaCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);

        private bool CanCloseWindowCommandExecute() => true;

        private void OnCloseWindowCommandExecuted()
        {
            CloseWindow(!IsStringsEmpty());
        }

        #endregion CloseWindow

        #region SaveData command

        private ICommand _saveDataCommand;

        public ICommand SaveDataCommand => _saveDataCommand
            ??= new LambdaCommand(OnSaveDataCommandExecuted, CanSaveDataCommandExecute);

        private bool CanSaveDataCommandExecute() => true;

        private void OnSaveDataCommandExecuted()
        {
            SaveData();
        }

        #endregion SaveData

        #region LoadPreviousCheckup command

        private ICommand _loadPreviousCheckupCommand;

        public ICommand LoadPreviousCheckupCommand => _loadPreviousCheckupCommand
            ??= new LambdaCommand(OnLoadPreviousCheckupCommandExecuted, CanLoadPreviousCheckupCommandExecute);

        private bool CanLoadPreviousCheckupCommandExecute() => true;

        private void OnLoadPreviousCheckupCommandExecuted()
        {
            LoadPreviousCheckup();
        }

        #endregion LoadPreviousCheckup

        private void CloseWindow(bool askFirst)
        {
            // isStringEmpty = true when there is nothing written
            if (askFirst)
            {
                var result =
                    MessageBox.Show(
                        "Вы уверены, что хотите Выйти? Все не сохраненные данные будут потеряны.",
                        "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.No) return;
            }
            _currentWindow.Close();
        }

        private void SaveData()
        {
            if (_doctorId != 0)
                CurrentCheckup.User = _authService.CurrentUser;

            bool saved = CurrentCheckup.Id == 0
                ? _checkupService.SaveNewCheckup(CurrentCheckup, _hospitalizationId)
                : _checkupService.SaveOldCheckup(CurrentCheckup);

            if (!saved)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            CloseWindow(false);
        }

        private void LoadPreviousCheckup()
        {
            if (IsStringsEmpty())
            {
                var result =
                    MessageBox.Show(
                        "Вы уверены, что хотите загрузить предыдущую запись? Все введенные данные будут потеряны.",
                        "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if(result == MessageBoxResult.No) return;
            }
            var newCheckup = new Checkup
            {
                View = _previousCheckup.View,
                Skin = _previousCheckup.Skin,
                Heart = _previousCheckup.Heart,
                Stomach = _previousCheckup.Stomach,
                Hormones = _previousCheckup.Hormones,
                Genitourinary = _previousCheckup.Genitourinary,
                Nervous = _previousCheckup.Nervous
            };

            CurrentCheckup = newCheckup;
        }

        private bool IsStringsEmpty()
        {
            bool isEmpty = true;
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.View);
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.Skin);
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.Heart);
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.Stomach);
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.Hormones);
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.Genitourinary);
            isEmpty &= string.IsNullOrEmpty(CurrentCheckup.Nervous);
            return isEmpty;
        }

        public void OpenExistingCheckup(CheckupWindow currentWindow, Checkup checkup)
        {
            CurrentCheckup = checkup;
            IsLoadButtonEnabled = false;
            _currentWindow = currentWindow;
        }

        public void OpenNewCheckup(CheckupWindow currentWindow, int hospitalizationId, int doctorId, Checkup? previousCheckup = null)
        {
            CurrentCheckup = new Checkup();
            _previousCheckup = previousCheckup;
            IsLoadButtonEnabled = _previousCheckup is not null;
            _currentWindow = currentWindow;
            _hospitalizationId = hospitalizationId;
            _doctorId = doctorId;
        }

        public CheckupWindowViewModel ( ICheckupService checkupService, IAuthService authService)
        {
            _checkupService = checkupService;
            _authService = authService;
        }
    }
}
