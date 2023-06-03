using System.Windows;

namespace MedApp.Services.Interfaces
{
    interface IMessageService
    {
        public void ShowError(string message, string header);

        public MessageBoxResult ShowQuestion(string message, string header,
            MessageBoxResult defaultAnswer = MessageBoxResult.No);

        public void ShowNotification(string message, string header);

        public string ShowFilePicker(string hint, string filter);
    }
}
