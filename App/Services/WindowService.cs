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
        private readonly DiagnosisWindowViewModel _diagnosisWindowViewModel;
        private readonly MkbListWindowViewModel _mkbListWindowViewModel;
        private readonly MoveWindowViewModel _moveWindowViewModel;

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
            _examinationWindowViewModel.OpenExistingExamination(window, examination);
            window.ShowDialog();
        }

        public void OpenNewExaminationWindow(int hospitalizationId)
        {
            var window = new ExaminationWindow();
            _examinationWindowViewModel.OpenNewExamination(window,hospitalizationId);
            window.ShowDialog();
        }

        public void OpenDiagnosisWindow(Hospitalization hospitalization)
        {
            var window = new DiagnosisWindow();
            _diagnosisWindowViewModel.OpenWindow(window, hospitalization, this);
            try
            {
                window.ShowDialog();
            }
            catch{}
        }

        public Mkb OpenMkbListWindow()
        {
            var window = new MkbListWindow();
            _mkbListWindowViewModel.OpenWindow(window);
            window.ShowDialog();
            return _mkbListWindowViewModel.GetSelectedMKb();
        }

        public void OpenMoveWindow(Hospitalization hospitalization)
        {
            var window = new MoveWindow();
            _moveWindowViewModel.OpenWindow(window, hospitalization);
            window.ShowDialog();
        }

        public WindowService(
            CheckupWindowViewModel checkupWindowViewModel, 
            ExaminationWindowViewModel examinationWindowViewModel, 
            DiagnosisWindowViewModel diagnosisWindowViewModel,
            MkbListWindowViewModel mkbListWindowViewModel,
            MoveWindowViewModel moveWindowViewModel)
        {
            _checkupWindowViewModel = checkupWindowViewModel;
            _examinationWindowViewModel = examinationWindowViewModel;
            _diagnosisWindowViewModel = diagnosisWindowViewModel;
            _mkbListWindowViewModel = mkbListWindowViewModel;
            _moveWindowViewModel = moveWindowViewModel;
        }

    }
}
