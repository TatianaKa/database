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
    /// <summary>
    /// Логика взаимодействия для Meneg.xaml
    /// </summary>
    public partial class Meneg : Window
    {
        public Meneg()
        {
            InitializeComponent();
            Userss users = new Userss();
            var auth = Enitition.context.Userss.ToList();
            dtg.ItemsSource = auth;
        }
    }
}
