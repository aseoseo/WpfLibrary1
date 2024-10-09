using System;

namespace TaskApp
{
    public class TaskManager
    {
        // Делегат для выполнения задачи
        public delegate void TaskDelegate(string task);

        // Метод для добавления задачи и выполнения действия через делегат
        public void AddTask(string task, TaskDelegate taskDelegate)
        {
            taskDelegate?.Invoke(task);  // Выполняем делегат (действие)
        }
    }
}
