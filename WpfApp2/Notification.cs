using System;

namespace MobileApp
{
    public class Notification
    {
        // События для отправки уведомлений
        public event Action<string> OnMessageSent;
        public event Action<string> OnCallMade;
        public event Action<string> OnEmailSent;

        // Метод для отправки сообщения
        public void SendMessage(string message)
        {
            OnMessageSent?.Invoke(message); // Вызов события для сообщения
        }

        // Метод для совершения звонка
        public void MakeCall(string number)
        {
            OnCallMade?.Invoke(number); // Вызов события для звонка
        }

        // Метод для отправки email
        public void SendEmail(string email)
        {
            OnEmailSent?.Invoke(email); // Вызов события для email
        }
    }
}
