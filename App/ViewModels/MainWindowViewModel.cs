using MedApp.ViewModels.Base;

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

        #endregion
    }
}
