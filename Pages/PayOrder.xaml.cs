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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Логика взаимодействия для PayOrder.xaml
    /// </summary>
    public partial class PayOrder : Window
    {
            public int SummaBankForOrder { get; set; } = App.SummaBankCard;
            List<Assets.ProductsInOrder> listProductsInOrders = MakeOrder.listProductsInOrders;

        public PayOrder()
        {

            InitializeComponent();
            SecretOrder.ItemsSource = MakeOrder.listProductsInOrders;
            clickbuy.Content = $"Оплатить: {App.SummaOrder}";
        }
        //Переход на главное окно
        private void BackOnMainWindow(object sender, RoutedEventArgs e)
        {
            App.SummaOrder = 0;
            App.Current.Windows[0].Title = "MainWindow";
            foreach (Window window in App.Current.Windows)
            {
                if (!(window is MainWindow))
                    window.Close();
            }
        }
        private void settingsorder(object sender, RoutedEventArgs e)
        {
            string name;
            int index;
            string doing = (sender as Button).Name;
            Assets.ProductsInOrder product = (sender as Button).DataContext as Assets.ProductsInOrder;

            int count, cost, newcosting;
            switch (doing)
            {
                case "plus":
                    count = product.Count;
                    cost = product.Cost;
                    if (App.SummaOrder + cost < SummaBankForOrder)
                    {
                        newcosting = (count + 1) * cost;
                        product.Costing = newcosting;
                        product.Count = count + 1;
                        App.SummaOrder += cost;
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств");
                    }
                    break;
                case "minus":
                    count = product.Count;
                    cost = product.Cost;
                    if (count == 1)
                    {
                        name = product.Name;
                        App.SummaOrder -= cost;
                        index = MakeOrder.listProductsInOrders.FindIndex(x => x.Name == name);
                        MakeOrder.listProductsInOrders.RemoveAt(index);
                    }
                    else
                    {
                        newcosting = (count - 1) * cost;
                        product.Costing = newcosting;
                        product.Count = count - 1;
                        App.SummaOrder -= cost;
                    }
                    break;
                case "delete":
                    name = product.Name;
                    count = product.Count;
                    cost = product.Cost;
                    index = MakeOrder.listProductsInOrders.FindIndex(x => x.Name == name);
                    MakeOrder.listProductsInOrders.RemoveAt(index);
                    App.SummaOrder -= (cost * count);
                    break;
            }
            SecretOrder.Items.Refresh();
            clickbuy.Content = $"Оплатить: {App.SummaOrder}";
        }
        private void makeCheck(object sender, RoutedEventArgs e)
        {
            //Объекты Word

            Word.Application wordApp;           //Приложение Word
            Word.Document wordDoc;          //Документ Word
            Word.Table wordTable;               //Таблица 
            Word.InlineShape wordShape;         //Рисунок
            Word.Paragraph wordPar, tablePar;       //Абзацы документа и таблицы
            Word.Range wordRange, tablRange;        //Тест абзаца и таблицы

            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = false;
            }
            catch
            {
                MessageBox.Show("Товарный чек в Word создать не удалось");
                return;
            }
            //Добавить новый документ
            wordDoc = wordApp.Documents.Add();
            //Ориентация страницы - книжная
            wordDoc.PageSetup.BottomMargin = 20;
            wordDoc.PageSetup.TopMargin = 20;
            wordDoc.PageSetup.LeftMargin = 20;
            wordDoc.PageSetup.RightMargin = 20;
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
            wordDoc.Content.ParagraphFormat.LeftIndent = wordDoc.Content.Application.CentimetersToPoints((float)0);
            wordDoc.Content.ParagraphFormat.RightIndent = wordDoc.Content.Application.CentimetersToPoints((float)0);
            //Выравнивание текста в абзацах
            wordDoc.Content.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            //Доступ к 1-му существующему параграфу
            wordPar = (Word.Paragraph)wordDoc.Paragraphs[1];
            //Добавление нового параграфа  после существующего
            //Настройки параграфа
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //------------------------------------------------------------------------------------
            wordRange = wordPar.Range;      //Его содержимое
            //Добавление новой картинки
            wordShape = wordDoc.InlineShapes.AddPicture(App.pathExe + @"/Res/LOGOTIP.png", Type.Missing, Type.Missing, wordRange);
            //Настройка картинки
            wordShape.Width = 250;
            wordShape.Height = 250;
            //------------------------------------------------------------------------------------
            wordRange.InsertParagraphAfter();

            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange = wordPar.Range;
            wordRange.Font.Size = 20;
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Name = "Sylfaen";
            Random rnd = new Random();
            wordRange.Text = "ЗАКАЗ #" + rnd.Next(1, 1000);

            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordRange = wordPar.Range;
            wordRange.Font.Size = 16;
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Name = "Sylfaen";
            wordRange.Text = "Дата заказа: " + DateTime.Now.ToLongDateString();
            //------------------------------------------------------------------------------------
            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();     //Абзац для таблицы
            wordRange = wordPar.Range;      //Диапазон абзаца		
            wordTable = wordDoc.Tables.Add(wordRange, SecretOrder.Items.Count + 1, 7);
            wordTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle; //Бордюр
            Word.Range cellRange;           //Отдельная ячейка таблицы
            for (int col = 1; col <= 7; col++)
            {
                cellRange = wordTable.Cell(1, col).Range;   //Ссылка к нужной ячейке
                cellRange.Text = SecretOrder.Columns[col - 1].Header.ToString();    //Значение из ЭУ
            }
            wordTable.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorLightBlue;
            wordTable.Rows[1].Range.Font.Color = Word.WdColor.wdColorWhite;
            wordTable.Rows[1].Range.Font.Name = "Sylfaen";
            wordTable.Rows[1].Range.Font.Size = 15;
            wordTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //------------------------------------------------------------------------------------
            wordPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wordPar.set_Style("Заголовок 2");               //Стиль, взятый из Word
            for (int row = 2; row <= listProductsInOrders.Count + 1; row++)
            {
                wordTable.Rows[row].Shading.ForegroundPatternColor = Word.WdColor.wdColorGray05;
                wordTable.Rows[row].Range.Font.Color = Word.WdColor.wdColorBlack;
                wordTable.Rows[row].Range.Font.Name = "Sylfaen";
                wordTable.Rows[row].Range.Font.Size = 15;
                wordRange.Font.Size = 14;
                wordRange.Font.Color = Word.WdColor.wdColorBlack;
                wordRange.Font.Name = "Time New Roman";
                cellRange = wordTable.Cell(row, 1).Range;
                wordTable.Columns.SetWidth(70, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustProportional);
                cellRange = wordTable.Cell(row, 2).Range;
                cellRange.Text = listProductsInOrders[row - 2].Name.ToString();
                cellRange = wordTable.Cell(row, 3).Range;
                cellRange = wordTable.Cell(row, 5).Range;
                cellRange.Text = listProductsInOrders[row - 2].Cost.ToString();
                cellRange = wordTable.Cell(row, 6).Range;
                cellRange.Text = listProductsInOrders[row - 2].Count.ToString();
                cellRange = wordTable.Cell(row, 7).Range;
                cellRange.Text = listProductsInOrders[row - 2].Costing.ToString();
            }

            wordRange.InsertParagraphAfter();
            wordPar = wordDoc.Paragraphs.Add();
            wordRange = wordPar.Range;               //Стиль, взятый из Word
            wordRange.Font.Color = Word.WdColor.wdColorBlue;
            wordRange.Font.Size = 20;
            wordRange.Font.Name = "Sylfaen";
            wordRange.Text = "Стоимость заказа: " + App.SummaOrder.ToString() + " рублей";

            //Сохранить документ в двух форматах: docx и pdf 
            wordDoc.Saved = true;
            //Полный путь к документу с именем – текущей даты
            string pathDoc = App.pathExe + @"\checks" + "test";
            wordDoc.SaveAs(pathDoc + ".docx");
            //Сохранить в формате pdf
            wordDoc.SaveAs(pathDoc + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            wordDoc.Close(true, null, null);
            wordApp.Quit();                     //Выход из Word
                                                //Вызвать свою подпрограмму убивания процессов
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordApp);
            //Заставляет сборщик мусора провести сборку мусора
            GC.Collect();

        }
    }
    
}
