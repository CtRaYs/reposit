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
    /// Логика взаимодействия для MakeOrder.xaml
    /// </summary>
    public partial class MakeOrder : Window
    {
        List<string> listCat;
        List<Assets.Product> listProducts;
        public static List<Assets.ProductsInOrder> listProductsInOrders;

        int SummaOrder = App.SummaOrder;
        

        public MakeOrder()
        {

            InitializeComponent();
            makeCategoryList();
            Random rnd = new Random();
            App.SummaBankCard = rnd.Next(1000000, 3000000);
            wallet.Text = App.SummaBankCard.ToString();

            this.DataContext = this;
            listProductsInOrders = new List<Assets.ProductsInOrder>();//(4)

        }
        //Переход на главное окно
        private void BackOnMainWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MovePayOrder(object sender, RoutedEventArgs e)
        {
            App.SummaOrder = SummaOrder;
            Pages.PayOrder payorder = new Pages.PayOrder();
            this.Hide();
            payorder.ShowDialog();
        }
        private void InOrderClick(object sender, RoutedEventArgs e)
        {

            Assets.ProductsInOrder productInOrder;//(1)

            Assets.Product product = (sender as Button).DataContext as Assets.Product;//(2)
            string productName = product.Name;
            int productCost = product.Cost;

            if (SummaOrder + productCost <= App.SummaBankCard)//(3)
            {
                SummaOrder += productCost;//(3.1)
                limit.Text = "Сумма товаров: " + SummaOrder;

                int index = listProductsInOrders.FindIndex(x => x.Name == productName);//(3.2)

                if (index < 0)//(3.2.1)
                {
                    productInOrder = new Assets.ProductsInOrder();//(3.2.1.1)
                    productInOrder.Name = productName;
                    productInOrder.Cost = productCost;
                    productInOrder.Count = 1;
                    productInOrder.Costing = productCost;
                    listProductsInOrders.Add(productInOrder);//(3.2.1.2)
                }
                else//(3.2.2)
                {
                    listProductsInOrders[index].Count++;//((3.2.2.1))
                    listProductsInOrders[index].Costing = listProductsInOrders[index].Cost * listProductsInOrders[index].Count;
                }
            }
            else//(4)
            {
                MessageBox.Show("У вас недостаточно средств");//(5)
            }
        }
        //Функция поиска и сбора всех листов из Excel
        private void makeCategoryList()
        {
            listCategory.Items.Clear();
            listCat = new List<string>();

            foreach (Excel.Worksheet item in App.excelWorkBook.Worksheets)
            {
                listCat.Add(item.Name);
            }

            listCategory.ItemsSource = listCat;
        }

        private void listCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string categoryName = listCategory.SelectedItem.ToString();//(1)

            listProducts = new List<Assets.Product>();//(2)
            Assets.Product product;

            App.excelWorkSheet = (Excel.Worksheet)App.excelWorkBook.Worksheets.get_Item(categoryName);//(3)
            App.excelRange = App.excelWorkSheet.UsedRange;

            for (int row = 1; row <= App.excelRange.Rows.Count; row++)//(4)
            {
                product = new Assets.Product();//(4.1)
                product.Name = Convert.ToString(App.excelRange.Cells[row, 1].value2);//(4.2)
                product.Cost = Convert.ToUInt16(App.excelRange.Cells[row, 2].value2);

                //string url = App.pathExe + $@"/photo/{categoryName}/{product.Name}.png";//(4.3)
                //string def = App.pathExe + @"/default.png";

                //product.Photo = url;

                listProducts.Add(product);//(4.5)
            }

            listProduct.ItemsSource = listProducts;//(5)
        }
    }
    
}
