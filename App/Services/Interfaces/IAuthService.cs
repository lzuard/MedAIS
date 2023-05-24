using MedData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Services.Interfaces
{
    internal interface IAuthService
    {
        public User? CurrentUser { get; }

        public User? LogIn(string login, string password);

        public void LogOut();

        public string GetHelp();
    }
}
