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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace _02_FlowDoc_Practice
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

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream fs = File.Open("1.xaml", FileMode.Create))
            {
                XamlWriter.Save(docViewer.Document, fs); // using System.Windows.Markup;
            }
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Open("1.xaml", FileMode.Open))
            {
                docViewer.Document = XamlReader.Load(fs) as FlowDocument;
            }
        }

        private void btn_Like_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Мне тоже не нравится дизайн. Завтра сделаю лучше!", "Важное дополнение", MessageBoxButton.OK);
        }
    }
}
