using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace _06_Example
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

        /// <summary>
        /// USA cash converter
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double rate = Convert.ToDouble(usRate.Text);
            double amount = Convert.ToDouble(usAmount.Text);
            usResult.Text = (rate * amount).ToString();
        }

        /// <summary>
        /// Euro cash converter
        /// </summary>
        private void buttonEurCalculate_Click(object sender, RoutedEventArgs e)
        {
            double rate = Convert.ToDouble(eurRate.Text);
            double amount = Convert.ToDouble(eurAmount.Text);
            eurResult.Text = (rate * amount).ToString();
        }

        /// <summary>
        /// Japan cash converter
        /// </summary>
        private void buttonJpnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double rate = Convert.ToDouble(jpnRate.Text);
            double amount = Convert.ToDouble(jpnAmount.Text);
            jpnResult.Text = (rate * amount).ToString();
        }

        /// <summary>
        /// Code to get all current rates from central bank of russian federation
        /// </summary>
        private void buttonGetFromWeb_Click(object sender, RoutedEventArgs e)
        {
            usRate.Text = "";
            eurRate.Text = "";
            jpnRate.Text = "";

            // combined from internet sources =)
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.cbr-xml-daily.ru/latest.js");
            HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader responseReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string line = "";
                double num = 0;
                while ((line = responseReader.ReadLine()) != null)
                {
                    // find proper lines to get rates
                    if (line.Contains("USD") && usRate.Text == "")
                    {
                        line = line.Split(':')[1].Trim(' ', ',').Replace('.', ',');
                        num = 1 / Convert.ToDouble(line);
                        usRate.Text = String.Format($"{num:0.00}");
                    }
                    if (line.Contains("EUR") && eurRate.Text == "")
                    {
                        line = line.Split(':')[1].Trim(' ', ',').Replace('.', ',');
                        num = 1 / Convert.ToDouble(line);
                        eurRate.Text = String.Format($"{num:0.00}");
                    }
                    if (line.Contains("JPY") && jpnRate.Text == "")
                    {
                        line = line.Split(':')[1].Trim(' ', ',').Replace('.', ',');
                        num = 1 / Convert.ToDouble(line);
                        jpnRate.Text = String.Format($"{num:0.00}");
                    }
                }
            }
        }

        /// <summary>
        /// Distance converter logic
        /// </summary>
        private void buttonConvertDistance_Click(object sender, RoutedEventArgs e)
        {
            double input = 1;
            double output = 1;
            // set multiplier from "From combo box"
            switch ((comboBoxFrom.SelectedItem as ComboBoxItem).Content as String)
            {
                case "Millimeters":
                    input = 1;
                    break;
                case "Meters":
                    input = 1000;
                    break;
                case "Inches":
                    input = 25.4;
                    break;
                default:
                    input = 1;
                    break;
            }
            // set multiplier from "To combo box"
            switch ((comboBoxTo.SelectedItem as ComboBoxItem).Content as String)
            {
                case "Millimeters":
                    output = 1;
                    break;
                case "Meters":
                    output = 1000;
                    break;
                case "Inches":
                    output = 25.4;
                    break;
                default:
                    output = 1000;
                    break;
            }
            // math
            if (textBoxFrom.Text != "")
            {
                double result = Convert.ToDouble(textBoxFrom.Text) * input / output;
                // set result to field
                textBoxTo.Text = String.Format($"{result:0.0000}");
            }
            else
            {
                MessageBox.Show("Please enter some value", "Attention");
            }
        }
    }
}
