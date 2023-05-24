using MedApp.Services.Interfaces;
using MedData.Entities;
using MedData.Interfaces;
using System.Linq;

namespace MedApp.Services
{
    internal class AuthService : IAuthService
    {
        private User? _currentUser = null;
        private readonly IRepository<User> _repository;

        public User? CurrentUser
        {
            get => _currentUser;
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
                    _currentUser = user;
                    return _currentUser;
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
            _currentUser = null;
        }
    }
}

