using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _03_Themes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Создадим код для выбора темы
            // СПисок
            List<String> styles = new List<string>() { "Light", "Black" };
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChange; // установим привязку события до установления значниея ComboBox
            styleBox.SelectedIndex = 1;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            // ищем словари ресурсов
            // Получаем ResourceDictionary для MergedDictionaries
            int styleIndex = styleBox.SelectedIndex; // считаекм значение с комбобокса
            Uri uri = new Uri("White.xaml", UriKind.Relative); // получаем ссылку на ресурс светлой темы
            if (styleIndex == 1) // если значение комбобокса = 1 поменять на темную
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);  // получаем ссылку на ресурс темной темы
            }
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            // сначала очистим весь список что бы убрать все ресурсы
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
        }
    }
}
