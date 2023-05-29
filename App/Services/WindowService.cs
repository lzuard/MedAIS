using MedApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedApp.ViewModels;
using MedApp.Views;
using MedData.Entities;

namespace MedApp.Services
{
    internal class WindowService: IWindowService
    {
        private readonly CheckupWindowViewModel _checkupWindowViewModel;

        public void OpenExistingCheckupWindow(Checkup checkup)
        {
            var window = new CheckupWindow();
            _checkupWindowViewModel.OpenExistingCheckup(window,checkup);
            window.ShowDialog();
        }

        public void OpenNewCheckupWindow(int hospitalizationId, int doctorId, Checkup? previousCheckup = null)
        {
            var window = new CheckupWindow();
            _checkupWindowViewModel.OpenNewCheckup(window, hospitalizationId, doctorId, previousCheckup);
            window.ShowDialog();
        }

        public void OpenExistingExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public void OpenNewExaminationWindow(int hospitalizationId)
        {
            throw new NotImplementedException();
        }

        public WindowService(CheckupWindowViewModel checkupWindowViewModel)
        {
            _checkupWindowViewModel = checkupWindowViewModel;
        }

    }
}
