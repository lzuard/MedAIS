using System.Linq;
using MedApp.Views;
using System.Windows;
using MedData.Entities;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MedApp.ViewModels.Base;
using System.Collections.Generic;
using MedApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedApp.ViewModels
{
    internal class DiagnosisWindowViewModel:ViewModelBase
    {
        /*------------------------------------------------------------Private properties------------------*/
        private readonly IDiagnosisService _diagnosisService;
        private readonly IMessageService _messageService;
        private IWindowService _windowService;
        private DiagnosisWindow _window;
        private Hospitalization _hospitalization;

        /*Private properties------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Binding properties------------------*/
        #region DiagnosisList

        private ObservableCollection<Diagnosis> _diagnosisList;

        public ObservableCollection<Diagnosis> DiagnosisList
        {
            get => _diagnosisList;
            set => Set(ref _diagnosisList, value);
        }

        #endregion Diagnoses

        #region SelectedDiagnosisIndex

        private int _selectedDiagnosisIndex;

        public int SelectedDiagnosisIndex
        {
            get => _selectedDiagnosisIndex;
            set => Set(ref _selectedDiagnosisIndex, value);
        }

        #endregion SelectedDiagnosisIndex

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

        #region Save command

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new LambdaCommand(OnSaveCommandExecuted, CanSaveCommandExecute);

        private bool CanSaveCommandExecute() => true;

        private void OnSaveCommandExecuted()
        {
            SaveChanges();
        }

        #endregion Save

        #region OpenMkbList command

        private ICommand _openMkbListCommand;

        public ICommand OpenMkbListCommand => _openMkbListCommand
            ??= new LambdaCommand(OnOpenMkbListCommandExecuted, CanOpenMkbListCommandExecute);

        private bool CanOpenMkbListCommandExecute() => true;

        private void OnOpenMkbListCommandExecuted()
        {
            OpenMkbList();
        }

        #endregion OpenMkbList

        /*Commands------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Commands methods------------------*/
        private void OpenMkbList()
        {
            var result = _windowService.OpenMkbListWindow();
            if (result is not null)
            {
                try
                {
                    DiagnosisList.ElementAt(SelectedDiagnosisIndex).Mkb = result;
                }
                catch {}
            }
        }

        private void CloseWindow(bool quit)
        {
            if (!quit)
            {
                var result =
                    _messageService.ShowQuestion("Вы уверены, что хотите выйти? Все несохраненные данные будут утеряны",
                        "Вы уверены?");
                if (result != MessageBoxResult.Yes) return;
            }
            _window.Close();
        }

        private void SaveChanges()
        {
            var saved = _diagnosisService.SaveChanges(DiagnosisList, _hospitalization);
            if (saved)
                CloseWindow(true);
            else
                _messageService.ShowError("Ошибка сохранения", "Ошибка");
        }

        /*Commands methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Private methods------------------*/
        private void InitData()
        {
            //Init diagnosis lists
            var diagnosisList = _diagnosisService.GetDiagnosisList(_hospitalization.Id);
            DiagnosisList = diagnosisList is null
                ? new ObservableCollection<Diagnosis>(new List<Diagnosis> { new Diagnosis() })
                : new ObservableCollection<Diagnosis>(diagnosisList);
        }

        /*Private methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Public methods------------------*/
        public void OpenWindow(DiagnosisWindow window, Hospitalization hospitalization, IWindowService windowService)
        {
            _window = window;
            _hospitalization = hospitalization;
            _windowService = windowService;

            try
            {
                InitData();
            }
            catch
            {
                _messageService.ShowError("Ошибка инициализации данных", "Ошибка");
                CloseWindow(true);
            }
        }
        /*Public methods------------------------------------------------------------------------------*/
        /*------------------------------------------------------------Ctor------------------*/
        public DiagnosisWindowViewModel(IDiagnosisService diagnosisService, IMessageService messageService)
        {
            _diagnosisService = diagnosisService;
            _messageService = messageService;
        }
        /*Ctor------------------------------------------------------------------------------*/
    }
}
