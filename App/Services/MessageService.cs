using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MathCore.PE.Headers;
using MedApp.Services.Interfaces;

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
    }
}
