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

namespace _00_Start
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnButton1_Click(object sender, RoutedEventArgs e)
        {
            txtBlock.FontSize += 5;
        }
    }
    public class Person
        /* Что бы воспользоваться Binding и получать данные из пользовательского класса он должен быть:
         * public
         * Получать можно только public свойства
         */
    {
        public string FIO { get; set; }
        public int Age { get; set; }
    }
    public static class Person1
    /* Что бы воспользоваться Binding и получать данные из пользовательского класса он должен быть:
     * public
     * Получать можно только public свойства
     */
    {
        public static string FIO { get; set; } = "Григорий";
        public static int Age { get; set; } = 20;
    }
}
