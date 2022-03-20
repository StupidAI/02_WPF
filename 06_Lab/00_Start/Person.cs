using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _00_Start
{
    /*
     *  Демонстрация как сделать свойство объекта в WPF на основе класса Person. Первоначально класс был создан стандартным
     *  Далее для свойства Age внесены изменения что бы оно стало своством зависимости (поэтому часть кода закомментирована)
     *  Класс необходимо наследовать от DependencyObject (using System.Windows;)
     *  В свойстве Age напрямую не провродится проверок - потому что это переносится в свойство зависимости в статическом конструкторе Person
     *  
     *  На данном этапе ничего проверить нельзя - не хватает знаний как создавать элементы WPF
     */
    class Person : DependencyObject
    {
        //СВойство зависимости
        public static readonly DependencyProperty AgeProperty;

        // Поля
        private string name;
        //private int age; - убираем это поле при создании зависимости
        // Свойства
        public string Name { get; set; }
        public int Age
        {
            // Стандартные свойства модифицируем
            //get
            //{
            //    return age;
            //} 
            get => (int) GetValue(AgeProperty);
            //set
            //{
            //    if (value >0&& value<200)
            //    {
            //        age = value;
            //    }
            //    else
            //    {
            //        age = 0;
            //    }
            //}
            set => SetValue(AgeProperty, value);
        }
        // Конструктор
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        // Статический конструктор: вызовется только 1 раз. Нужен для инициализации AgeProperty
        static Person()
        {
            AgeProperty = DependencyProperty.Register
                (
                    nameof(Age), //имя свойства
                    typeof(int), //тип данных свойства
                    typeof(Person), //класс объекта
                    new FrameworkPropertyMetadata
                    (
                        0, // значение по молчанию
                        FrameworkPropertyMetadataOptions.AffectsMeasure | //Может менять размер объекта в зависимости от наполнения
                        FrameworkPropertyMetadataOptions.AffectsRender, //Перерисовывает объект
                        null,
                        new CoerceValueCallback(CoerseAge) //Корректирует значение
                    ),
                    new ValidateValueCallback(ValidateAge) //определяет верно ли значение
                );
        }
        // реализация метода ValidateAge
        private static bool ValidateAge(object value)
        {
            int v = (int)value;
            if (v >= 0 && v <= 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Реализация метода для корректировки значения Age
        private static object CoerseAge(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= 0) // Можно предусмотреть тут проверку на большое число, чего не может быть, но в условиях учебы мы эту проверку сделали в ValidateAge
            {
                return v;
            }
            else
            {
                return 0;
            }
        }

        // Метод класса
        public string Print()
        {
            return $"{Name} {Age}";
        }
        
    }
}
