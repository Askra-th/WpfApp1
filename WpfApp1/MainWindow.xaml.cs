using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using (var db = new ChvalyukvaCwContext())
            {
                db.Database.EnsureCreated();
            }
            InitializeComponent();
        }
        private void Registration1_Click(object sender, RoutedEventArgs e)
        {
            Window1 reg = new Window1();
            this.Hide();
            reg.ShowDialog();
            this.Show();
        }

        private void Enter1_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Passwordbox.Password;
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            try
            {
                using (var context = new ChvalyukvaCwContext())
                {
                    var user = context.Customers.FirstOrDefault(e => e.Email == login && e.Pasword == password);
                    if (user != null)
                    {
                        Window2 main = new Window2();
                        this.Hide();
                        main.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:{ex.Message}");
            }

        }
    }
}