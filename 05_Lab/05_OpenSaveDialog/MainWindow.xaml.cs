using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _05_OpenSaveDialog
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // using Microsoft.Win32 required
            ofd.Filter = "Text files (*.txt)|*.txt;*.doc|All files(*.*)|*.*"; //first part for user | second for list | ... repeat
            if (ofd.ShowDialog() == true)
            {
                textBoxMain.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, textBoxMain.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
