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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFModernVerticalMenu.Assets;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;



namespace WPFModernVerticalMenu.Pages
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {


        List<string> listCat;
        List<Assets.Product> listProducts;
        public Products()
        {
            InitializeComponent();
            makeCategoryList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
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

                string url = App.pathExe + $@"/photo/{categoryName}/{product.Name}.png";//(4.3)
                string def = App.pathExe + @"/default.png";

                product.Photo = url;

                listProducts.Add(product);//(4.5)
            }

            listProduct.ItemsSource = listProducts;//(5)
        }
    }
}
