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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        bool boll1 = false;

        List<Product45> FFF = new List<Product45>();

        public Window2()
        {
            InitializeComponent();

        }
        private void LoadProducts()
        {
            try
            {
                using (var contex = new ChvalyukvaCwContext())
                {
                    IQueryable<Product> products = contex.Products;
                    if (boll1 == true) 
                    {
                        products = products.Where(p => p.Price > 29999);
                    }
                   
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            boll1 = true;
            LoadProducts();
        }
        private void Sorting(object sender, RoutedEventArgs e)
        {

        }
    }
    public class Product45
    {
        public string Name3 { get; set; }
        public string Price { get; set; }
        public override string ToString() => $"{Name3} {Price}";
     
        

    }
}
