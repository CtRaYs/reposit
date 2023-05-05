using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFModernVerticalMenu.Assets
{
    public class Product
    {
        public string Photo { get; set; }	//Изображение блюда
        public string Name { get; set; }	//Название блюда
        public int Cost { get; set; }	//Цена блюда
    }
    public class ProductsInOrder : Product
    {
        public int Count { get; set; } //Кол-во товаров
        public int Costing { get; set; }//Общая стоимость
    }

}
