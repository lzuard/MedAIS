using MedApp.ViewModels.Base;

namespace MedApp.ViewModels
{
    class DebugWindowViewModel: ViewModelBase
    {

        private string _title = "DebugWindow";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
