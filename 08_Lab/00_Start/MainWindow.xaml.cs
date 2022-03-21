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
            /* Так как для кнопки 1 ресурс статичный - то цвет в процессе работы программы не будет меняться
             * Обращаемся к ресурсам Window - потому this
             * Для кнопки 3 ресурс динамический - и цвет кнопки поменяется
             */
            this.Resources["SCBRed"] = new SolidColorBrush(Colors.Blue);
        }
    }
}
