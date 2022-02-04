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

namespace _08_Example
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
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void comboBoxFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
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
    }
}
