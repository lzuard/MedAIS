using System.Windows.Documents;
using System.Windows.Markup;
using MedApp.ViewModels.Base;
using MedData.Entities;

namespace MedApp.ViewModels
{
    internal class CheckupWindowViewModel : ViewModelBase
    {
        #region CurrentCheckup

        private Checkup _currentCheckup;

        public Checkup CurrentCheckup
        {
            get => _currentCheckup;
            set => Set(ref _currentCheckup, value);
        }

        #endregion CurrentCheckup



        public void OpenExistingCheckup(Checkup checkup)
        {
            CurrentCheckup = checkup;
        }

        public void OpenNewCheckup(int hospitalizationId)
        {
            CurrentCheckup = new Checkup();
        }
    }
}
