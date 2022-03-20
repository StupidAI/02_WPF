using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _01_Weather
{
    /* 1. Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку – 
     * температуру (целое число в диапазоне от -50 до +50),
     * направление ветра (строка), скорость ветра (целое число), 
     * наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег. 
     * Можно использовать целочисленное значение, либо создать перечисление enum). 
     * Свойство «температура» преобразовать в свойство зависимости.
     */
    class WeatherControl : DependencyObject
    {
        #region RegularClass
        // Структура класса по умолчанию
        // Поля класса
        private int temp;
        private string direction;
        private PrecipitationList precipitation;
        // перечислитель для осадков (кажется что ему тут не место, возможно стоит создавать отдельный класс)
        private enum PrecipitationList
        {
            Sunny = 0,
            Cloudy = 1,
            Rainy = 2,
            Snowy = 3
        }

        //Свойства класса
        //public int Temp { get => temp; set => temp = value; } // Тут было стандартное свойство, которое переделано
        public string Direction { get => direction; set => direction = value; }
        private PrecipitationList Precipitation { get => precipitation; set => precipitation = value; }
        //Метод класса для печати
        public string Print()
        {
            return $"Temp: {Temp}\nDirection: {Direction}\nPrecipitation is {Precipitation}";
        }
        #endregion

        #region DependencyProperty
        // Преобразование класса в свойство зависимости

        //Свойство зависимости
        public static readonly DependencyProperty TempProperty;

        //Преобразованное свойство
        public int Temp 
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        //Статический конструктор для инициализации своства зависимости
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                    nameof(Temp), //имя свойства
                    typeof(int), //тип данных свойства
                    typeof(WeatherControl), //класс объекта
                    new FrameworkPropertyMetadata
                    (
                        0, // значение по молчанию
                        FrameworkPropertyMetadataOptions.AffectsMeasure | //Может менять размер объекта в зависимости от наполнения
                        FrameworkPropertyMetadataOptions.AffectsRender, //Перерисовывает объект
                        null,
                        new CoerceValueCallback(CoerseTemp) //Корректирует значение
                    ),
                    new ValidateValueCallback(ValidateTemp) //определяет верно ли значение
                );
        }
        // реализация метода ValidateTemp для проверки корректности
        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Реализация метода для корректировки значения Temp
        private static object CoerseTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }
        #endregion

    }
}
