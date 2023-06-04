using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedApp.Views;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class MkbListWindowViewModel:ViewModelBase
    {
        private readonly IDiagnosisService _diagnosisService;
        private MkbListWindow _window;

        #region MkbList

        private IEnumerable<Mkb> _mkbList;

        public IEnumerable<Mkb> MkbList
        {
            get => _mkbList;
            set => Set(ref _mkbList, value);
        }

        #endregion MkbList

        #region SelectedMkbIndex

        private int _selectedMkbIndex;

        public int SelectedMkbIndex
        {
            get => _selectedMkbIndex;
            set => Set(ref _selectedMkbIndex, value);
        }

        #endregion SelectedMkbIndex

        #region CloseWindow command

        private ICommand _chooseMkbCommand;

        public ICommand ChooseMkbCommand => _chooseMkbCommand
            ??= new LambdaCommand(OnChooseMkbCommandExecuted, CanChooseMkbCommandExecute);

        private bool CanChooseMkbCommandExecute() => true;

        private void OnChooseMkbCommandExecuted()
        {
            CloseWindow();
        }

        #endregion CloseWindow

        private void CloseWindow()
        {
            _window.Close();
        }

        public void OpenWindow(MkbListWindow window)
        {
            _window = window;
        }

        public Mkb GetSelectedMKb()
        {
            return MkbList.ElementAt(SelectedMkbIndex);
        }

        public MkbListWindowViewModel(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
            MkbList = _diagnosisService.GetMkbList();
        }
    }
}
