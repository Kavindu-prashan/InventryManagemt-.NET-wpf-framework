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
    /// Interaction logic for viewsuplier.xaml
    /// </summary>
    public partial class viewsuplier : Window
    {
        List<user> items = new List<user>();
        public viewsuplier()
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
        string suplier_ID;
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                user selectedValue = (user)lvUsers.SelectedValue;
                user view = selectedValue;
                suplier_ID = view.ID;
                suplierId.Text = suplier_ID;
            }
            catch (Exception ex)
            {

            }
        }

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


                //   string b_id = Convert.ToString(reader1["s_id"]);
                //    string size = Convert.ToString(reader1["size"]);
                //   string quantity = Convert.ToString(reader1["qty"]);
                string bra1 = Convert.ToString(reader["brand1"]);
                string bra2 = Convert.ToString(reader["brand2"]);
                string bra3 = Convert.ToString(reader["brand3"]);
                string bra4 = Convert.ToString(reader["brand4"]);

                view_brand1.Text = bra1;
                view_brand2.Text = bra2;
                view_brand3.Text = bra3;
                view_brand4.Text = bra4;

                string name = Convert.ToString(reader["name"]);
                string mail = Convert.ToString(reader["email"]);
                string contact = Convert.ToString(reader["contact"]);
                string s_id = Convert.ToString(reader["s_id"]);

                search_name.Text = name;
                fullName.Text = name;
                Email.Text = mail;
                cntat.Text = contact;
                // b1.Text = bra1;

            }
            catch (Exception ex)
            { }

            //string query1 = "SELECT * FROM brands_t WHERE s_id = " + suplierId.Text;


            //SqlCommand select_brand = new SqlCommand(query1, connect);
            //connect.Open();
            //SqlDataReader reader1 = select_brand.ExecuteReader();
            //reader1.Read();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((pass.Password != "123") || (pass.Password == ""))
            {
                MessageBox.Show("Re-enter the password");
                pass.Clear();
            }
            else
            {
                try
                {
                    string query3 = "DELETE FROM suplier_t WHERE s_id='" + suplierId.Text + "'";
                    SqlCommand cmd_2 = new SqlCommand(query3, connect);
                    SqlDataReader myreader;

                    connect.Open();
                    myreader = cmd_2.ExecuteReader();
                    MessageBox.Show("Entry Deleted Successfully");

                    while (myreader.Read()) { }

                    search_name.Clear();
                    fullName.Clear();
                    Email.Clear();
                    cntat.Clear();
                    suplierId.Clear();
                    view_brand1.Clear();
                    view_brand2.Clear();
                    view_brand3.Clear();
                    view_brand4.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Entry not deleted");
                }
            }

        }

        private void cntat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void view_brand1_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string query_qty = "SELECT qty FROM brands_t WHERE s_id = '" + suplierId.Text + "' AND brand1='" + view_brand1.Text + "'";

        //    SqlCommand select_sup = new SqlCommand(query_qty, connect);
        //    connect.Open();
        //    SqlDataReader reader_qty = select_sup.ExecuteReader();
        //    reader_qty.Read();

        //    string bra_qty_show = Convert.ToString(reader_qty["brand1"]);


        //    br1_qty.Text = bra_qty_show;

        //}

    }
}
