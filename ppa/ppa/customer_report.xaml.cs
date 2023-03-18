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
    /// Interaction logic for customer_report.xaml
    /// </summary>
    public partial class customer_report : Window
    {
        List<user_1> items_1 = new List<user_1>();
        public customer_report()
        {
            InitializeComponent();

            try
            {

                connect.Close();
                items_1.Clear();
                connect.Open();
                string get_values = "SELECT * FROM customer_t";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string c_name = Convert.ToString(get_value["name"]);
                    string c_contact = Convert.ToString(get_value["contact"]);
                    string c_brand = Convert.ToString(get_value["brand"]);
                    string c_size = Convert.ToString(get_value["size"]);
                    string c_qty = Convert.ToString(get_value["qty"]);


                    items_1.Add(new user_1() { Name = c_name, Contact = c_contact, Brand = c_brand, Size = c_size, Qty = c_qty });
                }
                connect.Close();
                listView.ItemsSource = items_1;
                listView.Items.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }

        }



        public class user_1
        {
            public String Brand { get; set; }
            public String Size { get; set; }
            public String Qty { get; set; }
            public String Contact { get; set; }
            public String Name { get; set; }

        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


    }
}
