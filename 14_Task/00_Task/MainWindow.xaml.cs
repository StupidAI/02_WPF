using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _00_Task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products; // using System.Collections.ObjectModel;
        public MainWindow()
        {
            InitializeComponent();

            products = new ObservableCollection<Product>(); //Данный тип позволить получать уведомления об изменениях списка
            // 1 продукт
            products.Add(new Product()
            {
                ProductName = "Холодильник",
                Price = 200,
                ImagePath = "data/h.jpg",
                Category = Category.Tech
            });
            // 2 продукт
            products.Add(new Product()
            {
                ProductName = "Лапша",
                Price = 5,
                ImagePath = "data/l.jpg",
                Category = Category.Food
            });
            // 3 продукт
            products.Add(new Product()
            {
                ProductName = "Микроволновка",
                Price = 75,
                ImagePath = "data/m.jpg",
                Category = Category.Tech
            });
            // 4 продукт
            products.Add(new Product()
            {
                ProductName = "Сахар",
                Price = 1000000,
                ImagePath = "data/s.jpg",
                Category = Category.Food
            });
            lstBox.ItemsSource = products;
        }
    }
}