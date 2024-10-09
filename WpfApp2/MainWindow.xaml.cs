using System;
using System.Windows;

namespace MobileApp
{
    public partial class MainWindow : Window
    {
        private Notification notification;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация класса Notification
            notification = new Notification();

            // Регистрация обработчиков событий
            notification.OnMessageSent += HandleMessageSent;
            notification.OnCallMade += HandleCallMade;
            notification.OnEmailSent += HandleEmailSent;
        }

        // Обработчики событий
        private void HandleMessageSent(string message)
        {
            ResultTextBlock.Text = $"Сообщение отправлено: {message}";
        }

        private void HandleCallMade(string number)
        {
            ResultTextBlock.Text = $"Звонок совершен на номер: {number}";
        }

        private void HandleEmailSent(string email)
        {
            ResultTextBlock.Text = $"Email отправлен на адрес: {email}";
        }

        // Методы для отправки уведомлений
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            notification.SendMessage("Привет, это сообщение!");
        }

        private void MakeCall_Click(object sender, RoutedEventArgs e)
        {
            notification.MakeCall("8-800-555-35-35");
        }

        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            notification.SendEmail("example@example.com");
        }
    }
}
