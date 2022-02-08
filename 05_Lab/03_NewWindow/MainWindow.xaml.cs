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

namespace _03_NewWindow
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

        private void buttonNewWindow_Click(object sender, RoutedEventArgs e)
        {
            NewWindow win = new NewWindow();
            win.WindowStyle = WindowStyle.ToolWindow;
            //win.ShowDialog(); // modal window - only one window can be run
            win.Show(); // multiple window can be run
        }
    }
}
