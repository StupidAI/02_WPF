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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

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

        private void btn_OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            XpsDocument doc = new XpsDocument("data/2.xps", FileAccess.Read); // using System.Windows.Xps.Packaging; (... using System.IO;)
            docViewer.Document = doc.GetFixedDocumentSequence();
            doc.Close();
        }

        private void btn_SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            XpsDocument doc = new XpsDocument("1.xps", FileAccess.Write); // using System.Windows.Xps.Packaging; (... using System.IO;)
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc); // using System.Windows.Xps;
            writer.Write(docViewer.Document as FixedDocument);
            doc.Close();
        }
    }
}
