using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using MedData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedApp.ViewModels
{
    internal class DoctorsViewModel : ViewModelBase
    {
        private IAuthService _authService;

        private User? _curentUser;

        public User CurentUser
        {
            get => _curentUser;
            set => Set(ref _curentUser, value);
        }

        private string _username;
        public string UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private string _userPosition;
        public string UserPosition
        {
            get => _userPosition; 
            set => Set(ref _userPosition, value);
        }





        public DoctorsViewModel(IAuthService authService) 
        {
            //Debug
            authService.LogIn("adminUser", "adminUser");

            _authService = authService;
            _curentUser = authService.CurrentUser;




            _username = $"{_curentUser.Surname} {_curentUser.Name[0]}. {_curentUser.Patronymic[0]}.";

            _userPosition = _curentUser.Position.Name;
        }
    }
}
