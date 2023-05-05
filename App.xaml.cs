using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Excel.Application excelApp;     //Подключение приложение Excel
        public static Excel.Workbook excelWorkBook;   //Подключение отдельной книги
        public static Excel.Worksheet excelWorkSheet; //Подключение листов
        public static Excel.Range excelRange;         //Подключение используемых ячеек
        public static int SummaOrder { get; set; }
        public static int SummaBankCard { get; set; }

        public static string pathExe = Environment.CurrentDirectory;    //К файлу exe
        public static string fileMenu = pathExe + @"/menu.xlsx";
        public static string adminLogin = "";    //Админ логин
        public static string adminPassword = ""; //Админ пароль


        /*Формирование листа категорий: Определение экземпляра
            листа категорий товаров(1), цикл получения всех наименований листов из книги(2)*/
        public static List<string> makeCategoryList()
        {
            List<string> listCat;
            listCat = new List<string>();

            foreach (Excel.Worksheet item in App.excelWorkBook.Worksheets)//(2)
            {
                listCat.Add(item.Name);
            }
            return listCat;
        }

        public static string activeCategory = "";
        public static string activeProduct = "";
    }

}
