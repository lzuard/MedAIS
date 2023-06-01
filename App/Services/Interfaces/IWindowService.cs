using MedData.Entities;

namespace MedApp.Services.Interfaces
{
    interface IWindowService
    {
        public void OpenExistingCheckupWindow(Checkup checkup);

        public void OpenNewCheckupWindow(int hospitalizationId, int doctorId, Checkup? previousCheckup = null);

        public void OpenExistingExamination(Examination examination);

        public void OpenNewExaminationWindow(int  hospitalizationId);
    }
}
