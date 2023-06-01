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
        private readonly ExaminationWindowViewModel _examinationWindowViewModel;

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
            var window = new ExaminationWindow();
            window.ShowDialog();
        }

        public void OpenNewExaminationWindow(int hospitalizationId)
        {
            var window = new ExaminationWindow();
            window.ShowDialog();
        }

        public WindowService(CheckupWindowViewModel checkupWindowViewModel, ExaminationWindowViewModel examinationWindowViewModel)
        {
            _checkupWindowViewModel = checkupWindowViewModel;
            _examinationWindowViewModel = examinationWindowViewModel;
        }

    }
}
