using MedApp.Services.Interfaces;
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

        //public DebugWindowViewModel(IRepository<User> userRep, IAuthService authService)
        //{
        //    //var text = "";
        //    //var user =authService.LogIn("adminUser", "adminUser");

        //    //if (user is not null)
        //    //{
        //    //    text += user + $" - {user.Department.Name} - {user.Position.Name}";
        //    //}
        //    //else
        //    //    text = "wrong login/password";

        //    //_users = text;

        //}
    }
}
