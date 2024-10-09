using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private List<string> dataList;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация тестовых данных
            dataList = new List<string>
            {
                "Событие 1 - 2022",
                "Событие 2 - 2023",
                "Событие 3 - 2024",
                "Важное событие - 2023",
                "Запись в журнал - 2022"
            };

            // Отображение изначальных данных
            DisplayData(dataList);

            // Изначально показываем плейсхолдер
            PlaceholderText.Visibility = Visibility.Visible;
        }

        // Логика для отображения/скрытия плейсхолдера
        private void KeywordInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(KeywordInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        // Обработчик нажатия кнопки "Применить фильтр"
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilter = (FilterSelector.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedFilter == "Фильтр по дате")
            {
                var filteredData = FilterByDate(dataList);
                DisplayData(filteredData);
            }
            else if (selectedFilter == "Фильтр по ключевому слову")
            {
                string keyword = KeywordInput.Text;
                if (!string.IsNullOrEmpty(keyword))
                {
                    var filteredData = FilterByKeyword(dataList, keyword);
                    DisplayData(filteredData);
                }
                else
                {
                    ResultTextBlock.Text = "Введите ключевое слово!";
                }
            }
        }

        // Метод для фильтрации по дате
        private IEnumerable<string> FilterByDate(IEnumerable<string> data)
        {
            return data.Where(d => d.Contains("2023"));
        }

        // Метод для фильтрации по ключевому слову
        private IEnumerable<string> FilterByKeyword(IEnumerable<string> data, string keyword)
        {
            return data.Where(d => d.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));
        }

        // Метод для отображения данных
        private void DisplayData(IEnumerable<string> data)
        {
            ResultTextBlock.Text = string.Join(System.Environment.NewLine, data);
        }
    }
}
