using assesment3.Data;
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

namespace assesment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DContext con=new DContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username=txtuser.Text;
            var password = txtPass.Password;
            if(string.IsNullOrWhiteSpace(txtuser.Text)||string.IsNullOrWhiteSpace(txtPass.Password))
            {
                MessageBox.Show("complete");
                return;
            }
            var user=con.Users.FirstOrDefault(u=>u.UName==username||u.UPassword==password);
            if(user!=null)
            {
                if(user.URole== "Manager")
                {
                    Manager mm = new Manager();
                    mm.Show();
                    this.Close();
                }
                else if(user.URole== "Developer")
                {
                    Developer dd = new Developer(user.UserID);
                    dd.Show();
                    this.Close();
                }
            }
        }
    }
}