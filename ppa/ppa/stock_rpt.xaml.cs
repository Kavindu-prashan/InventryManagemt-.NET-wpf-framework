using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for stock_rpt.xaml
    /// </summary>
    public partial class stock_rpt : Window
    {
        List<user_1> items_1 = new List<user_1>();
        public stock_rpt()
        {
            InitializeComponent();

            try
            {

                connect.Close();
                items_1.Clear();
                connect.Open();
                string get_values = "SELECT * FROM brands_t";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string sup_id = Convert.ToString(get_value["s_id"]);
                    string b_brand = Convert.ToString(get_value["brand"]);
                    string b_size = Convert.ToString(get_value["size"]);
                    string b_qty = Convert.ToString(get_value["qty"]);
                    string b_price = Convert.ToString(get_value["price"]);


                    items_1.Add(new user_1() {S_id=sup_id, Brand = b_brand, Size = b_size, Qty = b_qty, Price = b_price});
                }
                connect.Close();
                listView.ItemsSource = items_1;
                listView.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        public class user_1
        {
            public String S_id { get; set; }
            public String Brand { get; set; }
            public String Size { get; set; }
            public String Qty { get; set; }

            public String Price { get; set; }

        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


    }
}
