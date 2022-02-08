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

namespace _02_PositionCenter
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

        private void buttonBackToCenter_Click(object sender, RoutedEventArgs e)
        {
            double width = SystemParameters.FullPrimaryScreenWidth;
            double height = SystemParameters.FullPrimaryScreenHeight;

            this.Top = (height - this.Height) / 2;
            this.Left = (width - this.Width) / 2;
        }
    }
}
