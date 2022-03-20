using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _00_Start
{
    class MyButton : Button
    {
        /*
         * Демонстрация как добавить событие объекта в WPF на основе класса Person на примере Button.
         * Класс должен наследоваться от UIElemen (using System.Windows;). В нашем случае Button (using System.Windows.Controls;)
         * наследуется от UIElement
         *  
         * В данном примере будут созданы кнопки с вложенностью и на выходе будут выдаваться message box-ы c именами кнопок показывающее
         * стратегию распространения Tunnel, Bubble, Direct (раскомментировать)
         */
        // 
        public static RoutedEvent MyButtonClickEvent;
        // Создается статический конструктор который вызывается 1 раз
        static MyButton()
        {
            MyButtonClickEvent = EventManager.RegisterRoutedEvent( //регистрация события
                nameof(MyButtonClick), //имя события
                RoutingStrategy.Tunnel, // тип события (спуск сверху вниз - см. лекцию). Стратегия распространения
                //RoutingStrategy.Bubble, // тип события (подъем cнизу вверх - см. лекцию). Стратегия распространения
                //RoutingStrategy.Direct, // тип события (только данное событие - см. лекцию). Стратегия распространения
                typeof(RoutedEventHandler), // тип события (делегата)
                typeof(MyButton)); // с каким классом связано событие
        }
        // событие
        public event RoutedEventHandler MyButtonClick
        {
            add { AddHandler(MyButtonClickEvent, value); }
            remove { RemoveHandler(MyButtonClickEvent, value); }
        }
        // для примера заменим обычное событие OnClick. Он будет вызывать обычное событие так как есть base.OnClick()
        // но так же будут вызываться события написаные нами
        protected override void OnClick()
        {
            base.OnClick();
            //Аргумент который будет передан обработчику событий
            RoutedEventArgs args = new RoutedEventArgs(MyButton.MyButtonClickEvent, this);
            // ВЫзов события. Событие которое должно быть вызвано определяется по параметрам объекта типа RoutedEventArgs
            RaiseEvent(args);
        }
    }
}
