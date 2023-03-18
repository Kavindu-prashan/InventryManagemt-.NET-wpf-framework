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

namespace ppa
{
    /// <summary>
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Window
    {
        public manager()
        {
            InitializeComponent();
        }

        private void Addsupplier_Click(object sender, RoutedEventArgs e)
        {
            addsuplier add = new addsuplier();
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewsuplier view = new viewsuplier();
            view.Show();
        }

        private void Addsupplier_Copy1_Click(object sender, RoutedEventArgs e)
        {
            new_customer cus = new new_customer();
            cus.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_stock add = new add_stock();
            add.Show();
        }

        private void Addsupplier_Copy_Click(object sender, RoutedEventArgs e)
        {
            view_stock vistk = new view_stock();
            vistk.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            reports rpt = new reports();
            rpt.Show();
            
        }
    }
    
}
