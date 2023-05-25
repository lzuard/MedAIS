using MedApp.Services.Interfaces;
using MedApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.ViewModels
{
    internal class AdminViewModel :ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        private IAuthService _authService;



        public void Activate(MainWindowViewModel mainWindowViewModel, IAuthService authService)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _authService = authService;
        }
    }
}
