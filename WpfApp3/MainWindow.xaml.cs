using System;
using System.Windows;
using System.Windows.Controls;

namespace TaskApp
{
    public partial class MainWindow : Window
    {
        private TaskManager taskManager;

        public MainWindow()
        {
            InitializeComponent();
            taskManager = new TaskManager();

            // Добавляем обработчик изменения текста в TextBox
            TaskInput.TextChanged += TaskInput_TextChanged;
        }

        // Логика для отображения/скрытия плейсхолдера
        private void TaskInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(TaskInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        // Обработчик нажатия кнопки "Добавить задачу"
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskInput.Text;
            if (string.IsNullOrEmpty(task))
            {
                ResultTextBlock.Text = "Введите задачу!";
                return;
            }

            // Определяем выбранное действие из ComboBox
            var selectedAction = (ActionSelector.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedAction == "Отправить уведомление")
            {
                // Используем делегат для отправки уведомления
                taskManager.AddTask(task, SendNotification);
            }
            else if (selectedAction == "Записать в журнал")
            {
                // Используем делегат для записи в журнал
                taskManager.AddTask(task, LogTask);
            }

            // Очищаем поле ввода
            TaskInput.Clear();
            PlaceholderText.Visibility = Visibility.Visible;
        }

        // Метод делегата: Отправить уведомление
        private void SendNotification(string task)
        {
            ResultTextBlock.Text = $"Уведомление: Задача \"{task}\" была успешно добавлена.";
        }

        // Метод делегата: Записать задачу в журнал
        private void LogTask(string task)
        {
            ResultTextBlock.Text = $"Журнал: Задача \"{task}\" была записана в журнал.";
        }
    }
}
