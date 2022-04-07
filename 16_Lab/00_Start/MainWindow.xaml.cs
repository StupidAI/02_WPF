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
using System.Windows.Media.Animation;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(); //using System.Windows.Media.Animation; МОжно менять только Double объекты
            //doubleAnimation.From = 150; // если это свойство не указывать то будет браться текущий размер
            doubleAnimation.To = 500; // Анимация ДО
            //doubleAnimation.By = 150; // Анимация увеличивает кнопку каждый раз на число
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            //doubleAnimation.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(6)); // Изменения будут повторяться пока не пройдет 6 сек
            //doubleAnimation.RepeatBehavior = new RepeatBehavior(2); // Анимация произойдет 2 раза
            //doubleAnimation.AccelerationRatio = 1; // ускорение 0 - линейная (без ускорения) ... 1 - с ускорением. Не целое значение - до какого момента будет ускорение а после него будет постоянной
            //doubleAnimation.SpeedRatio = 0.5; // замедление и ускорение времени. Если при норимальной скорости 2 - то станет 4
            doubleAnimation.AutoReverse = true; // изменния вернутся обратно плавно - проигрыш анимаци в обратном порядке
            doubleAnimation.FillBehavior = FillBehavior.Stop; // изменния вернутся обратно резко
            btn.BeginAnimation(Button.WidthProperty, doubleAnimation);
            btn.BeginAnimation(Button.HeightProperty, doubleAnimation);
            /*Имеются так же следующие линейные анимации:
             * ByteAnimation
             * ColorAnimation
             * DoubleAnimation
             * Int32Animation
             * PointAnimation
             * RectAnimation
             * SingleAnimation
             * ThicknessAnimation
             */

            ColorAnimation colorAnimation = new ColorAnimation();
            colorAnimation.From = Colors.Red;
            colorAnimation.To = Colors.Blue;
            colorAnimation.Duration = TimeSpan.FromSeconds(2);
            btn.Background = new SolidColorBrush(Colors.Red);
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            
        }
    }
}
