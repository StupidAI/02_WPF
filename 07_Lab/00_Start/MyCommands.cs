using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _00_Start
{
    class MyCommands
    {
        /* Класс который будет содержать все команды нашего приложения
         * Команды это свойства класса но они должны быть типа RoutedCommand, RoutedUICommand (using System.Windows.Input;)
         * RoutedCommand, RoutedUICommand - не содердат логики выполнения команды как таковой, суть в том что бы генерировать событие
         * которое начнет по дереву искать CommandBinding
         * 
         * Источниками команды могут быть только те элементы которые реализуют интерфейс ICommandSource
         */


        //// Свойства
        //public static RoutedCommand Exit { get; set; }

        //// Статический конструктор класса для инициализации команды
        //static MyCommands()
        //{
        //    //Exit = new RoutedCommand(); // Этого достаточно что бы использовать команду.
        //    InputGestureCollection inp = new InputGestureCollection(); // набор команд
        //    inp.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T")); //добавление к коллекции набора команд. Есть еще MouseGesture. Менюитем потом сам возьмет этот текст и добавит его в интерфейс
        //    Exit = new RoutedCommand("Exit", typeof(MyCommands), inp); //3й конструктор
        //}

        // Все то же только с RoutedUICommand
        // Свойства
        public static RoutedUICommand Exit { get; set; }

        // Статический конструктор класса для инициализации команды
        static MyCommands()
        {
            //Exit = new RoutedCommand(); // Этого достаточно что бы использовать команду.
            InputGestureCollection inp = new InputGestureCollection(); // набор команд
            inp.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T")); //добавление к коллекции набора команд. Есть еще MouseGesture. Менюитем потом сам возьмет этот текст и добавит его в интерфейс
            Exit = new RoutedUICommand("Выход", "Exit", typeof(MyCommands), inp); //По сравнению с RoutedCommand в XAML разметке не надо будет писать Header. Только Header можно так просто сделать. В кнопке такое сделать не так просто
        }

    }
}
