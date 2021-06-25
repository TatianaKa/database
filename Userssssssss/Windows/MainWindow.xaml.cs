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
using Userssssssss.Windows;

namespace Userssssssss
{
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCont_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Enitition.context.Userss.ToList().Where(i=> i.login==txtLogin.Text&& i.password==txtPass.Text).FirstOrDefault();
            if (userAuth.idRole==1)
            {
                Admin admin = new Admin();
                this.Hide();
                admin.ShowDialog();
                this.Show();
            }
            if (userAuth.idRole==2)
            {
                Meneg meneger = new Meneg();
                this.Hide();
                meneger.ShowDialog();
                this.Show();
            }
            if (userAuth.idRole==3)
            {
                User user = new User(userAuth);
                this.Hide();
                user.ShowDialog();
                this.Show();
            }
            
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.Show();
            Close();
        }
    }
}
