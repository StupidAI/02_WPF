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

namespace _04_MessageBox
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

        private void buttonMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
            MessageBox.Show("Test", "Window Name");
            MessageBox.Show("Test", "Window Name", MessageBoxButton.YesNoCancel);
            MessageBox.Show("Test", "Window Name", MessageBoxButton.YesNoCancel, MessageBoxImage.Hand);
        }
    }
}
