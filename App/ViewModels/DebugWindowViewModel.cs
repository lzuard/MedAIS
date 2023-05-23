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

            foreach (var u in users)
            {
                _users += $"{u.Id} - ФИО: {u.Surname} {u.Name} {u.Patronymic} - {u.Department.Name}\n";
            }



        }
    }
}
