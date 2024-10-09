using System;
using System.Windows;
using System.Windows.Controls;

namespace GeometryApp
{
    public partial class MainWindow : Window
    {
        // Делегат для вычисления площади
        private AreaDelegate areaDelegate;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик изменения выбора фигуры
        private void FigureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ParametersPanel.Children.Clear();
            var selectedFigure = (FigureComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedFigure == "Круг")
            {
                ParametersPanel.Children.Add(CreateInputField("Радиус:", "Radius"));
            }
            else if (selectedFigure == "Прямоугольник")
            {
                ParametersPanel.Children.Add(CreateInputField("Ширина:", "Width"));
                ParametersPanel.Children.Add(CreateInputField("Высота:", "Height"));
            }
            else if (selectedFigure == "Треугольник")
            {
                ParametersPanel.Children.Add(CreateInputField("Основание:", "Base"));
                ParametersPanel.Children.Add(CreateInputField("Высота:", "Height"));
            }
        }

        // Метод для создания поля ввода
        private UIElement CreateInputField(string label, string name)
        {
            var stack = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
            var lbl = new Label { Content = label, Width = 80 };
            var txt = new TextBox { Name = name + "TextBox", Width = 200 };
            stack.Children.Add(lbl);
            stack.Children.Add(txt);
            return stack;
        }

        // Обработчик нажатия кнопки "Рассчитать"
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedFigure = (FigureComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            Figure figure = null;

            try
            {
                if (selectedFigure == "Круг")
                {
                    double radius = GetParameterValue("Radius");
                    figure = new Circle(radius);
                }
                else if (selectedFigure == "Прямоугольник")
                {
                    double width = GetParameterValue("Width");
                    double height = GetParameterValue("Height");
                    figure = new Rectangle(width, height);
                }
                else if (selectedFigure == "Треугольник")
                {
                    double bas = GetParameterValue("Base");
                    double height = GetParameterValue("Height");
                    figure = new Triangle(bas, height);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите фигуру.");
                    return;
                }

                // Присваиваем делегату метод CalculateArea
                areaDelegate = figure.CalculateArea;

                // Вызываем делегат и отображаем результат
                double area = areaDelegate.Invoke();
                ResultTextBlock.Text = $"Площадь: {area:F2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Метод для получения значения параметра из TextBox
        private double GetParameterValue(string parameterName)
        {
            var textBox = FindName(parameterName + "TextBox") as TextBox;
            if (textBox == null)
                throw new Exception($"Поле {parameterName} не найдено.");

            if (double.TryParse(textBox.Text, out double value))
                return value;
            else
                throw new FormatException($"Некорректное значение для {parameterName}.");
        }
    }
}
