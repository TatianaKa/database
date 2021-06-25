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

namespace Userssssssss.Windows
{
    public partial class Add : Window
    {
        public bool Ed;
        public Userss userss1;
        public Add()
        {
            Ed = true;
            InitializeComponent();
            btn.Content = "добавить";

        }
        public Add(Userss userss)
        {
            InitializeComponent();
            Ed = false;
            txbName.Text = userss.LName;
            txbfName.Text = userss.FName;
            txblogin.Text = userss.login;
            txbPass.Text = userss.password;
            comboGen.SelectedItem = userss.idGender;
            comboRole.SelectedItem = userss.idRole;
            Enitition.context.SaveChanges();
            userss1 = userss;
            btn.Content = "изменить";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (Ed==true)
            {
            Userss cenguru = new Userss();
            cenguru.LName = txbName.Text;
            cenguru.FName = txbfName.Text;
            cenguru.login = txblogin.Text;
            cenguru.password = txbPass.Text;
            cenguru.idRole = comboRole.SelectedIndex + 1;

            if (comboGen.Text=="мужской")
            {
                cenguru.idGender = 1;
            }
            else
            {
                cenguru.idGender = 2;
            }

            Enitition.context.Userss.Add(cenguru);
            Enitition.context.SaveChanges();
            this.Close();
            Admin admin = new Admin();
            admin.Show();
            }
            else
            {
                userss1.FName = txbfName.Text;
                userss1.LName = txbName.Text;
                userss1.login = txblogin.Text;
                userss1.password = txbPass.Text;
                userss1.idRole = comboRole.SelectedIndex + 1;
                Enitition.context.SaveChanges();
                Close();
            }
            
            
        }
    }
}
