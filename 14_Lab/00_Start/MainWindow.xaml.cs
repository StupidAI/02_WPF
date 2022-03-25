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

namespace _00_Start
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Problem> problems; // using System.Collections.ObjectModel;
        public MainWindow()
        {
            InitializeComponent();
            //problems = new List<Problem>(); // Данный подход не очень хороший потому что если будет добавляться задание - то форма никак не узнает
            problems = new ObservableCollection<Problem>(); //Данный тип позволить получать уведомления об изменениях списка
            // 1 проблема
            problems.Add(new Problem()
            {
                ProblemName = "Задача 1",
                Description = "Выполнить домашнее задание",
                Priority = 2,
                ProblemType = ProblemType.Work
            });
            // 2 проблема
            problems.Add(new Problem()
            {
                ProblemName = "Задача 2",
                Description = "Полить цветы",
                Priority = 1,
                ProblemType = ProblemType.Home
            });
            // 3 проблема
            problems.Add(new Problem()
            {
                ProblemName = "Задача 3",
                Description = "Приготовить ужин",
                Priority = 1,
                ProblemType = ProblemType.Home
            });
            lstBox.ItemsSource = problems;
        }

        private void btnAddProblem_Click(object sender, RoutedEventArgs e)
        {
            problems.Add(new Problem()
            {
                ProblemName = "Задача 4",
                Description = "Покормить кота",
                Priority = 1,
                ProblemType = ProblemType.Home
            });
        }
    }
}
