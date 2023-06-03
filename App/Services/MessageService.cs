using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MathCore.PE.Headers;
using MedApp.Services.Interfaces;
using Microsoft.Win32;

namespace MedApp.Services
{
    public class MessageService : IMessageService

    {
        public void ShowError(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public MessageBoxResult ShowQuestion(string message, string header, MessageBoxResult defaultAnswer = MessageBoxResult.No)
        {
            return MessageBox.Show(message, header, MessageBoxButton.YesNo, MessageBoxImage.Question, defaultAnswer);
        }

        public void ShowNotification(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public string ShowFilePicker(string hint,string filter)
        {
            var file = "";
            var dialog = new OpenFileDialog
            {
                Filter = $"{hint} {filter}"
            };

            if (dialog.ShowDialog() == true)
                file = dialog.FileName;

            return file;
        }
    }
}
