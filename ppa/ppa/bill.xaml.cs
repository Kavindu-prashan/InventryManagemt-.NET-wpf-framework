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
    /// Interaction logic for bill.xaml
    /// </summary>
    public partial class bill : Window
    {
      


        public bill()
        {
            InitializeComponent();


            try
            {


                string shw_sid_query = "SELECT * FROM customer_t";
                SqlCommand shw_sid_cmd = new SqlCommand(shw_sid_query,connect);
                connect.Open();
                SqlDataReader read_sid = shw_sid_cmd.ExecuteReader();

                while (read_sid.Read())
                {
                 cus_id = Convert.ToString(read_sid["c_id"]);
                }

                show_id.Text = cus_id;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with loding ID");
            }



}
        string cus_id;


        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");



        private void show_id_TextChanged(object sender,TextChangedEventArgs e)
        {
            try
            {
                SqlConnection connect_1 = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                string query_1 = "SELECT * FROM customer_t WHERE c_id = " + show_id.Text;

                SqlCommand select_cus_details = new SqlCommand(query_1,connect_1);
                connect_1.Open();
                SqlDataReader reader_1 = select_cus_details.ExecuteReader();
                reader_1.Read();


                string names = Convert.ToString(reader_1["name"]);
                string contacts = Convert.ToString(reader_1["contact"]);



                name_txt.Text = names;
                cont_txt.Text = contacts;
            }
            catch { }


            try
            {

                SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");
            string query = "SELECT * FROM sales_t WHERE c_id = " + show_id.Text;

            SqlCommand select_cus = new SqlCommand(query,connect);
            connect.Open();
            SqlDataReader reader = select_cus.ExecuteReader();
            reader.Read();
            string brands = Convert.ToString(reader["brand"]);
            string sizess = Convert.ToString(reader["size"]);
            string qtys = Convert.ToString(reader["qty"]);
            string dis = Convert.ToString(reader["dis"]);
            string prices = Convert.ToString(reader["price"]);
            string dates = Convert.ToString(reader["date"]);



            brand_txt.Text = brands;
            size_txt.Text = sizess;
            qty_txt.Text = qtys;
            dis_txt.Text = dis;
            price_txt.Text = prices;
            date_txt.Text = dates;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with printing the Bill");
            }
        }
    }
}
