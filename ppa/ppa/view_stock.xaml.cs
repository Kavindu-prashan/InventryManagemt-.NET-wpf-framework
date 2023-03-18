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
    /// Interaction logic for view_stock.xaml
    /// </summary>
    public partial class view_stock : Window
    {
        List<user> items = new List<user>();
        List<user_1> items_1 = new List<user_1>();
        public view_stock()
        {
            InitializeComponent();


            try
            {
                connect.Close();
                items.Clear();
                connect.Open();
                string get_values = "SELECT * FROM suplier_t";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string s_name = Convert.ToString(get_value["name"]);
                    string s_identity = Convert.ToString(get_value["s_id"]);
                    items.Add(new user() { Name = s_name, ID = s_identity });
                    //   items.Add(new user() { employee_name = name, employee_id = e_id });
                }
                connect.Close();
                lvUsers.ItemsSource = items;

                lvUsers.Items.Refresh();
            }
            catch (Exception ex)
            {
                search_name.Text = "";
            }
        }
        public class user
        {
            public String Name { get; set; }
            public String ID { get; set; }
        }
        public class user_1
        {
            public String Brand { get; set; }
            public String Size { get; set; }
            public String Qty { get; set; }
        }

        string suplier_ID;
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


        private void search_name_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {//     MessageBox.Show("hi hih hiih");
                connect.Close();
                items.Clear();
                connect.Open();
                string get_values = "SELECT * FROM suplier_t WHERE name like '" + search_name.Text + "%'";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string s_name = Convert.ToString(get_value["name"]);
                    string s_identity = Convert.ToString(get_value["s_id"]);
                    items.Add(new user() { Name = s_name, ID = s_identity });
                    //   items.Add(new user() { employee_name = name, employee_id = e_id });
                }
                connect.Close();
                lvUsers.ItemsSource = items;

                lvUsers.Items.Refresh();
            }
            catch (Exception ex)
            {
                search_name.Text = "";
            }
        }

        private void suplierId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                string query = "SELECT * FROM suplier_t WHERE s_id = " + suplierId.Text;

                SqlCommand select_sup = new SqlCommand(query, connect);
                connect.Open();
                SqlDataReader reader = select_sup.ExecuteReader();
                reader.Read();
                string s_id = Convert.ToString(reader["s_id"]);

                string bra1 = Convert.ToString(reader["brand1"]);

                string bra2 = Convert.ToString(reader["brand2"]);

                string bra3 = Convert.ToString(reader["brand3"]);

                string bra4 = Convert.ToString(reader["brand4"]);


                string name = Convert.ToString(reader["name"]);
                string mail = Convert.ToString(reader["email"]);
                string contact = Convert.ToString(reader["contact"]);



                search_name.Text = name;
                fullName.Text = name;
                view_brand1.Text = bra1;
                view_brand2.Text = bra2;
                view_brand3.Text = bra3;
                view_brand4.Text = bra4;

                if (bra1 != "0")
                {
                    show_Brand1.Text = "1";
                }
                else
                {
                    show_Brand1.Text = "0";
                }
                if (bra2 != "0")
                {
                    show_Brand2.Text = "2";
                }
                else
                {
                    show_Brand2.Text = "0";
                }
                if (bra3 != "0")
                {
                    show_Brand3.Text = "3";
                }
                else
                {
                    show_Brand3.Text = "0";
                }
                if (bra4 != "0")
                {
                    show_Brand4.Text = "4";
                }
                else
                {
                    show_Brand4.Text = "0";
                }

                // b1.Text = bra1;

            }
            catch (Exception ex)
            { }

            try
            {
                connect.Close();
                items_1.Clear();
                connect.Open();
                string get_values = "SELECT * FROM brands_t WHERE s_id='" + suplierId.Text + "'";
                SqlCommand get = new SqlCommand(get_values, connect);
                SqlDataReader get_value = get.ExecuteReader();
                while (get_value.Read())
                {
                    string s_brand = Convert.ToString(get_value["brand"]);
                    string s_size = Convert.ToString(get_value["size"]);
                    string s_qty = Convert.ToString(get_value["qty"]);
                    items_1.Add(new user_1() { Size = s_size, Brand = s_brand, Qty = s_qty });
                }
                connect.Close();
                listView.ItemsSource = items_1;

                listView.Items.Refresh();
            }
            catch (Exception ex)
            {

            }



        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                user view = (user)lvUsers.SelectedValue;
                string iD = view.ID;
                suplier_ID = iD;
                suplierId.Text = suplier_ID;
            }
            catch (Exception ex)
            {

            }
        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            view_stock view = new view_stock();
            view.Show();
        }


    }
}
