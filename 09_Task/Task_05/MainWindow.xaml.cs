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

namespace Task_05
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

        #region FontFormatting
        /// <summary>
        /// Change fontSize and Family
        /// </summary>

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem as string; // Данные исправлены на string так как в словаре хранятся string объекты
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void comboBoxFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble((sender as ComboBox).SelectedItem); // Преобразуем Int16 -> Double
            if (textBox != null)
            {
                textBox.FontSize = fontSize;
            }
        }
        #endregion

        #region TextFormatting
        /// <summary>
        /// Set text Formatting: Italic, Bold, Underline
        /// </summary>

        private void buttonB_Click(object sender, RoutedEventArgs e)
        {
            // If button bressed - set border color to black. Button ON status indication
            if ((sender as Button).BorderBrush == Brushes.Transparent)
            {
                (sender as Button).BorderBrush = Brushes.Black;
            }
            else
            {
                (sender as Button).BorderBrush = Brushes.Transparent;
            }
            if (textBox != null)
            {
                textBox.FontWeight = (textBox.FontWeight == FontWeights.Bold) ?
                    textBox.FontWeight = FontWeights.Normal :
                    textBox.FontWeight = FontWeights.Bold;
            }
        }

        private void buttonI_Click(object sender, RoutedEventArgs e)
        {
            // If button bressed - set border color to black. Button ON status indication
            if ((sender as Button).BorderBrush == Brushes.Transparent)
            {
                (sender as Button).BorderBrush = Brushes.Black;
            }
            else
            {
                (sender as Button).BorderBrush = Brushes.Transparent;
            }
            if (textBox != null)
            {
                textBox.FontStyle = (textBox.FontStyle == FontStyles.Italic) ?
                    textBox.FontStyle = FontStyles.Normal :
                    textBox.FontStyle = FontStyles.Italic;
            }
        }

        private void buttonU_Click(object sender, RoutedEventArgs e)
        {
            // If button bressed - set border color to black. Button ON status indication
            if ((sender as Button).BorderBrush == Brushes.Transparent)
            {
                (sender as Button).BorderBrush = Brushes.Black;
            }
            else
            {
                (sender as Button).BorderBrush = Brushes.Transparent;
            }
            if (textBox != null)
            {
                textBox.TextDecorations = (textBox.TextDecorations == TextDecorations.Underline) ?
                    textBox.TextDecorations = null :
                    textBox.TextDecorations = TextDecorations.Underline;
            }
        }
        #endregion

        #region Color
        private void radioButtonBlack_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void radioButtonRed_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void radioButtonGreen_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Green;
            }
        }
        #endregion

        #region Menu
        /// <summary>
        /// Open
        /// </summary>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(ofd.FileName);
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, textBox.Text);
            }
        }
        /// <summary>
        /// Exit
        /// </summary>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        private void comboBoxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            int styleIndex = comboBoxTheme.SelectedIndex; // считаекм значение с комбобокса Theme
            Uri uri = new Uri("ThemeLight.xaml", UriKind.Relative); // получаем ссылку на ресурс светлой темы
            if (styleIndex == 1) // если значение комбобокса = 1 поменять на темную
            {
                uri = new Uri("ThemeDark.xaml", UriKind.Relative);  // получаем ссылку на ресурс темной темы (относительный путь)
            }
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(res);
        }
    }
}
