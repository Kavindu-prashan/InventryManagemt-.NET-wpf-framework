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
    /// Interaction logic for suplier_rpt.xaml
    /// </summary>
    /// 

    public partial class suplier_rpt : Window
    {
        List<user_1> items_1 = new List<user_1>();
        public suplier_rpt()
        {
            InitializeComponent();

            try
            {

                connect.Close();
                items_1.Clear();
                connect.Open();
                string get_values = "SELECT * FROM suplier_t";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string s_name = Convert.ToString(get_value["name"]);
                    string s_email = Convert.ToString(get_value["email"]);
                    string s_cont = Convert.ToString(get_value["contact"]);
                    string s_brand1 = Convert.ToString(get_value["brand1"]);
                    string s_brand2 = Convert.ToString(get_value["brand2"]);
                    string s_brand3 = Convert.ToString(get_value["brand3"]);
                    string s_brand4 = Convert.ToString(get_value["brand4"]);

                    items_1.Add(new user_1() { Name = s_name, Email = s_email, Contact = s_cont, Brand_1 = s_brand1, Brand_2 = s_brand2,Brand_3= s_brand3,Brand_4=s_brand4});
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
            public String Name { get; set; }
            public String Email { get; set; }
            public String Contact { get; set; }
            public String Brand_1 { get; set; }
            public String Brand_2 { get; set; }
            public String Brand_3 { get; set; }
            public String Brand_4 { get; set; }


        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


    }
}
