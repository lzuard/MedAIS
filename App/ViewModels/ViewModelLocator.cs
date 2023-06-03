using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public DebugWindowViewModel DebugWindowViewModel => App.Services.GetRequiredService<DebugWindowViewModel>();

        public AuthViewModel AuthViewModel =>App.Services.GetRequiredService<AuthViewModel>();

        public DoctorsViewModel DoctorsViewModel => App.Services.GetRequiredService<DoctorsViewModel>();

        public PatientViewModel PatientViewModel => App.Services.GetRequiredService<PatientViewModel>();
        public AdminViewModel AdminViewModel => App.Services.GetRequiredService<AdminViewModel>();

        public CheckupWindowViewModel CheckupWindowViewModel =>
            App.Services.GetRequiredService<CheckupWindowViewModel>();

        public ExaminationWindowViewModel ExaminationWindowViewModel =>
            App.Services.GetRequiredService<ExaminationWindowViewModel>();

        public DiagnosisWindowViewModel DiagnosisWindowViewModel =>
            App.Services.GetRequiredService<DiagnosisWindowViewModel>();
    }
}
