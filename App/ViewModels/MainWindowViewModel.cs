using MathCore.WPF.Commands;
using MedApp.ViewModels.Base;
using System.Windows.Input;

namespace MedApp.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        #region Properties

        #region Window Title
        private string _title = "МедАИС - Медицинская автоматизированная система";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion
        #region Curent viewmodel
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        #endregion

        #endregion

        #region Commands

        #region Next view command
        private ICommand _nextViewCommand;

        public ICommand NextViewCommand => _nextViewCommand
            ??= new LambdaCommand(OnNextViewCommandExecuted, CanNextViewCommandExecute);


        private bool CanNextViewCommandExecute() => true;

        private void OnNextViewCommandExecuted()
        {
            CurrentViewModel = new DoctorsViewModel();
        }
        #endregion
        #region Previous view command
        private ICommand _previousViewCommand;

        public ICommand PreviousViewCommand => _previousViewCommand
            ??= new LambdaCommand(OnPreviousViewCommandExecuted, CanPreviousViewCommandExecute);


        private bool CanPreviousViewCommandExecute() => true;

        private void OnPreviousViewCommandExecuted()
        {
            CurrentViewModel = new AuthViewModel();
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {

        }

    }
}
