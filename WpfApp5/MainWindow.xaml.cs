using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        // Делегат для сортировки
        private delegate int[] SortDelegate(int[] numbers);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumbersInput_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }
        // Обработчик нажатия кнопки "Сортировать"
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение чисел из текстового поля
                int[] numbers = NumbersInput.Text.Split(',')
                                  .Select(n => int.Parse(n.Trim()))
                                  .ToArray();

                // Определение метода сортировки на основе выбора пользователя
                SortDelegate sortMethod;
                if ((SortMethodSelector.SelectedItem as ComboBoxItem).Content.ToString() == "Сортировка пузырьком")
                {
                    sortMethod = BubbleSort;
                }
                else
                {
                    sortMethod = QuickSort;
                }

                // Выполнение сортировки
                int[] sortedNumbers = sortMethod(numbers);

                // Отображение результата
                ResultTextBlock.Text = "Отсортированные числа: " + string.Join(", ", sortedNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Метод сортировки пузырьком
        private int[] BubbleSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Обмен значениями
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }

        // Метод быстрой сортировки
        private int[] QuickSort(int[] numbers)
        {
            if (numbers.Length <= 1)
                return numbers;

            int pivot = numbers[numbers.Length / 2];
            int[] left = numbers.Where(n => n < pivot).ToArray();
            int[] right = numbers.Where(n => n > pivot).ToArray();
            int[] equal = numbers.Where(n => n == pivot).ToArray();

            return QuickSort(left).Concat(equal).Concat(QuickSort(right)).ToArray();
        }
    }
}
