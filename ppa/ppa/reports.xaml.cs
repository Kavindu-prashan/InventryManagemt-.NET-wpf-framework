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
    /// Interaction logic for reports.xaml
    /// </summary>
    public partial class reports : Window
    {
        public reports()
        {
            InitializeComponent();
        }

        private void cust_rpt_Click(object sender, RoutedEventArgs e)
        {
            customer_report cus = new customer_report();
            cus.Show();
        }

        private void sale_rpt_Click(object sender, RoutedEventArgs e)
        {
            sales_rpt sale = new sales_rpt();
            sale.Show();

        }

        private void sup_rpt_Click(object sender, RoutedEventArgs e)
        {
            suplier_rpt sup = new suplier_rpt();
            sup.Show();
        }

        private void stk_rpt_Click(object sender, RoutedEventArgs e)
        {
            stock_rpt stk = new stock_rpt();
            stk.Show();
        }
    }
}
