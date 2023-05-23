using MedApp.ViewModels.Base;
using MedData.Entities;
using MedData.Interfaces;
using System.Linq;
using System.Windows.Documents;

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

        private string _users = "Nothing here";
        public string Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        public DebugWindowViewModel(IRepository<User> userRep)
        {
            var users = userRep.Items.Take(1);
            var text = "";
            foreach (var u in users)
            {
                text += u + $" - {u.Department.Name} - {u.Position.Name}";
            }

            _users = text;

        }
    }
}
