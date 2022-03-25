using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Task
{
    /* Определить класс Product для хранения информации о товаре. Класс должен содержать характеристики 
     * Название товара (строка), 
     * Цена (число), 
     * Изображение (строка - путь к файлу с изображением), 
     * Категория (перечисление, возможные значения – Еда, Бытовая техника)
     */

    // Список категорий
    public enum Category
    {
        Food = 1,
        Tech = 2
    }

    // Класс продукта
    public class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }

        // переопределение метода для тестирования вывода информации о продукте в строку
        public override string ToString()
        {
            return $"{ProductName}: {Price} - {Category}";
        }
    }
}
