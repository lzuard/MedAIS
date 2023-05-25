using MedApp.Services.Interfaces;
using MedData;
using MedData.Entities;
using MedData.Interfaces;
using System.Linq;

namespace MedApp.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IRepository<User> _repository;
        private User? _curentUser;

        public User? CurrentUser
        {
            get => _curentUser;
        }

        public AuthService (IRepository<User> repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Procced authentification
        /// </summary>
        public User? LogIn(string login, string password)
        {
            try
            {
                var user = _repository.Items.First(l => l.Login == login);
                if (user.Password == password)
                {
                    _curentUser = user;
                    return user;
                }
                else
                    throw new System.InvalidOperationException();
            }
            catch 
            {
                return null;
            }
            
        }

        public void LogOut()
        {
            _curentUser = null;
        }

        public string GetHelp()
        {
            try
            {
                var text = "";
                var admins = _repository.Items.Where(i => i.Department.Name.Contains("IT")==true).ToArray();
                if (admins.Length == 0 ) throw new System.Exception();
                foreach (var admin in admins)
                {
                    text += admin.GetNamePositionAndPhone() + "\n\n";
                }
                return text;
            }
            catch 
            {
                return "Сотрудники отдела IT не найдены!";
            }
            

        }
    }
}

