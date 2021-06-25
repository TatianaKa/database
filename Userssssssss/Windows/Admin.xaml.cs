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
    public partial class Admin : Window
    {
        List<Userss> userList = new List<Userss>();
        List<Role> roleList = new List<Role>();
       
        public Admin()
        {
            InitializeComponent();
            var auth = Enitition.context.Userss.ToList();
            dtg.ItemsSource = auth;
            userList = Enitition.context.Userss.ToList();
            roleList = Enitition.context.Role.ToList();
            roleList.Insert(0,new Role {RoleName="Все пользователи"});

            cmb.ItemsSource = roleList;
            cmb.DisplayMemberPath = "idRole";
            cmb.SelectedIndex = 0;
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            Hide();
        }
        private void Filter()
        {
            if (cmb.SelectedIndex!=0)
            {
                userList = userList.Where(i => i.idRole== cmb.SelectedIndex).ToList();
            }
            userList = userList.Where(i => i.FName.Contains(txbSearch.Text)
            || i.FI.Contains(txbSearch.Text)
            || i.LName.Contains(txbSearch.Text)).ToList();


            dtg.ItemsSource = userList;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dtg.SelectedItem is Userss user)
            {
                Add add = new Add(user);
                User user1 = new User(user);
                add.ShowDialog();
                var ress = MessageBox.Show("Вы точно хотите изменить пользователя?", "ЭЭ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ress == MessageBoxResult.Yes)
                {
                    dtg.ItemsSource = Enitition.context.Userss.ToList();
                    Show();
                }

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ress = MessageBox.Show("Вы точно хотите удалить пользователя?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ress == MessageBoxResult.Yes)
            {
                if (dtg.SelectedItem is Userss user)
                {
                    Enitition.context.Userss.Remove(user);
                    Enitition.context.SaveChanges();
                    dtg.ItemsSource = Enitition.context.Userss.ToList();
                }

            }
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
