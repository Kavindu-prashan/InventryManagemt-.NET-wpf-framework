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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<user> items = new List<user>();
        public Window1()
        {
            InitializeComponent();
        }
        public class user
        {
            public String Brand { get; set; }
            public String Size { get; set; }
            public String Qty { get; set; }
        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connect.Close();
                items.Clear();
                connect.Open();
                string get_values = "SELECT * FROM brands_t WHERE s_id='"+qty_b1.Text+"'";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string s_brand = Convert.ToString(get_value["brand"]);
                    string s_size = Convert.ToString(get_value["size"]);
                    string s_qty = Convert.ToString(get_value["qty"]);
                    items.Add(new user() {  Size = s_size, Brand = s_brand , Qty= s_qty });
                    //   items.Add(new user() { employee_name = name, employee_id = e_id });
                }
                connect.Close();
                listView.ItemsSource = items;

                listView.Items.Refresh();
            }
            catch (Exception ex)
            {
            
            }

        }
    }
}
