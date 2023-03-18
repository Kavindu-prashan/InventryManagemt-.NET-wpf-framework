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
    /// Interaction logic for add_stock.xaml
    /// </summary>
    public partial class add_stock : Window
    {

        string suplier_ID;
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRESS; Initial Catalog=ppa; Integrated Security=SSPI;");

        List<user> items = new List<user>();


        public add_stock()
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
            catch (Exception)
            {
                search_name.Text = "";
            }


            category.Items.Add("10*");
            category.Items.Add("13*");
            category.Items.Add("13.5*");
            category.Items.Add("14*");
            category.Items.Add("17");
            category.Items.Add("42");


            category.SelectedIndex = -1;
        }
        public class user
        {
            public String Name { get; set; }
            public String ID { get; set; }
        }

        double item_size;
        int item_brand1;
        int item_brand2;
        int item_brand3;
        int item_brand4;
        string sup_id;
        int item_brand;
        int item_b;

       

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
                // b1.Text = bra1;

            }
            catch (Exception ex)
            { }

        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                user view = (user)(lvUsers.SelectedValue);
                suplier_ID = view.ID;
                suplierId.Text = suplier_ID;
            }
            catch (Exception ex)
            {

            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            if (category.SelectedIndex == 0)
            {
                // item_role = 1;
                item_size = 10;
            }
            else if (category.SelectedIndex == 1)
            {
                // item_role = 2;
                item_size = 13;
            }
            else if (category.SelectedIndex == 2)
            {
                //item_role = 3;
                item_size = 13.5;
            }
            else if (category.SelectedIndex == 3)
            {
                // item_role = 4;
                item_size = 14;
            }

            else if (category.SelectedIndex == 4)
            {
                //  item_role = 5;
                item_size = 17;
            }
            else if (category.SelectedIndex == 5)
            {
                // item_role = 6;
                item_size = 42;
            }
            if (suplierId.Text == "")
            {
                MessageBox.Show("Error With Id");
            }
            else
            {

               if (view_price.Text != "")
              { 


                    if (first_combo.IsChecked == true)
                    {
                        item_brand1 = 1;
                        item_brand = 1;
                    }
                    else if (second_combo.IsChecked == true)
                    {
                        item_brand2 = 2;
                        item_brand = 2;
                    }
                    else if (third_combo.IsChecked == true)
                    {
                        item_brand3 = 3;
                        item_brand = 3;
                    }
                    else if (fourth_combo.IsChecked == true)
                    {
                        item_brand4 = 4;
                        item_brand = 4;
                    }

                    if ((category.SelectedIndex == 0) || (category.SelectedIndex == 1) || (category.SelectedIndex == 2) || (category.SelectedIndex == 3) || (category.SelectedIndex == 4) || (category.SelectedIndex == 5))
                    {


                        if ((first_combo.IsChecked == true) || (second_combo.IsChecked == true) || (third_combo.IsChecked == true) || (fourth_combo.IsChecked == true))
                        {
                            if (qty.Text == "")
                            {
                                MessageBox.Show("Error 0 Quntity ");
                            }
                            else
                            {
                                try
                                {
                                    SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRESS; Initial Catalog=ppa; Integrated Security=SSPI;");

                                        if (first_combo.IsChecked == true)
                                        {


                                            string query_1 = "UPDATE brands_t set qty=qty+ '" + qty.Text + "' WHERE brand ='1' AND size='" + item_size + "' AND s_id='" + suplierId.Text + "'";
                                            SqlCommand cmd_1 = new SqlCommand(query_1, connect);
                                            connect.Open();
                                            cmd_1.ExecuteNonQuery();
                                            connect.Close();

                                        }

                                        else if (second_combo.IsChecked == true)
                                        {
                                            string query_2 = "UPDATE brands_t set qty=qty+ '" + qty.Text + "' WHERE brand ='2' AND size='" + item_size + "' AND s_id='" + suplierId.Text + "'";

                                            SqlCommand cmd_2 = new SqlCommand(query_2, connect);

                                            connect.Open();
                                            cmd_2.ExecuteNonQuery();
                                            connect.Close();
                                        }
                                        else if (third_combo.IsChecked == true)
                                        {
                                            string query_3 = "UPDATE brands_t set qty=qty+ '" + qty.Text + "' WHERE brand ='3' AND size='" + item_size + "' AND s_id='" + suplierId.Text + "'";

                                            SqlCommand cmd_3 = new SqlCommand(query_3, connect);

                                            connect.Open();
                                            cmd_3.ExecuteNonQuery();
                                            connect.Close();
                                        }
                                        else if (fourth_combo.IsChecked == true)
                                        {
                                            string query_4 = "UPDATE brands_t set qty=qty+ '" + qty.Text + "' WHERE brand ='4' AND size='" + item_size + "' AND s_id='" + suplierId.Text + "'";

                                            SqlCommand cmd_4 = new SqlCommand(query_4, connect);

                                            connect.Open();
                                            cmd_4.ExecuteNonQuery();
                                            connect.Close();
                                        }

                                        qty.Clear();

                                    if (first_combo.IsChecked == true)
                                    {
                                        first_combo.IsChecked = !first_combo.IsChecked;
                                    }
                                    if (second_combo.IsChecked == true)
                                    {
                                        second_combo.IsChecked = !second_combo.IsChecked;
                                    }
                                    if (third_combo.IsChecked == true)
                                    {
                                        third_combo.IsChecked = !third_combo.IsChecked;
                                    }
                                    if (fourth_combo.IsChecked == true)
                                    {
                                        fourth_combo.IsChecked = !fourth_combo.IsChecked;
                                    }


                                    category.SelectedValue = -1;
                                        connect.Close();

                                        MessageBox.Show("Updated the values");
                                    view_price.Clear();

                                }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error");

                                    }
                             }
                        }

                        else
                        {
                            MessageBox.Show("Error,Select a brand"); //checking the selected value in combo box

                        }


                    }
                    else if (category.SelectedIndex == -1)
                    {
                        MessageBox.Show("Error,Select a tire size"); //checking the selected value in combo box
                    }

                }//dfghjk
                else
                {


                    SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRESS; Initial Catalog=ppa; Integrated Security=SSPI;");
                    if ((qty.Text == "") || (price_txt.Text == ""))
                    {
                        MessageBox.Show("Error...");
                    }
                    else
                    { 
                        if (first_combo.IsChecked == true)
                        {
                            string query_one = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + suplierId.Text + "','1','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";

                            SqlCommand cmd_one = new SqlCommand(query_one, connect);

                            connect.Open();
                            cmd_one.ExecuteNonQuery();
                            connect.Close();
                        }

                        else if (second_combo.IsChecked == true)
                        {
                            string query_two = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + suplierId.Text + "','2','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";
                            SqlCommand cmd_two = new SqlCommand(query_two, connect);

                            connect.Open();
                            cmd_two.ExecuteNonQuery();
                            connect.Close();
                        }
                        else if (third_combo.IsChecked == true)
                        {
                            string query_three = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + suplierId.Text + "','3','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";
                            SqlCommand cmd_three = new SqlCommand(query_three, connect);

                            connect.Open();
                            cmd_three.ExecuteNonQuery();
                        }
                        else if (fourth_combo.IsChecked == true)
                        {
                            string query_four = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + suplierId.Text + "','4','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";

                            SqlCommand cmd_four = new SqlCommand(query_four, connect);

                            connect.Open();
                            cmd_four.ExecuteNonQuery();
                            connect.Close();
                        }


                        qty.Clear();
                        price_txt.Clear();
                        view_price.Clear();

                        if (first_combo.IsChecked == true)
                        {
                            first_combo.IsChecked = !first_combo.IsChecked;
                        }
                        if (second_combo.IsChecked == true)
                        {
                            second_combo.IsChecked = !second_combo.IsChecked;
                        }
                        if (third_combo.IsChecked == true)
                        {
                            third_combo.IsChecked = !third_combo.IsChecked;
                        }
                        if (fourth_combo.IsChecked == true)
                        {
                            fourth_combo.IsChecked = !fourth_combo.IsChecked;
                        }

                        category.SelectedValue = -1;
                        connect.Close();

                        MessageBox.Show("Updated the values !!!!!!");

                    }

                }


            }
        }

        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(first_combo.IsChecked==true)
            {
                item_b = 1;
            }
            else if(second_combo.IsChecked==true)
            {
                item_b = 2;
            }
            else if (third_combo.IsChecked == true)
            {
                item_b = 3;
            }
            else if (fourth_combo.IsChecked == true)
            {
                item_b = 4;
            }



            try
            {
                if (category.SelectedIndex == 0)
                {
                    MessageBox.Show("You have selected size 10*");

                    string query = "SELECT * FROM brands_t WHERE  size='10' AND brand= '" + item_b+"' AND  s_id = " + suplierId.Text;

                    SqlCommand select_sup = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader reader = select_sup.ExecuteReader();
                    reader.Read();

                    string p_id = Convert.ToString(reader["price"]);
                    view_price.Text = p_id;

                }
                if (category.SelectedIndex == 1)
                {
                    MessageBox.Show("You have selected size 13*");
                    string query = "SELECT * FROM brands_t WHERE size='13' AND brand= '" + item_b + "' AND  s_id = " + suplierId.Text;

                    SqlCommand select_sup = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader reader = select_sup.ExecuteReader();
                    reader.Read();

                    string p_id = Convert.ToString(reader["price"]);
                    view_price.Text = p_id;


                }

                if (category.SelectedIndex == 2)
                {
                    MessageBox.Show("You have selected size 13.5*");
                    string query = "SELECT * FROM brands_t WHERE size='13.5' AND brand= '" + item_b + "' AND  s_id = " + suplierId.Text;

                    SqlCommand select_sup = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader reader = select_sup.ExecuteReader();
                    reader.Read();

                    string p_id = Convert.ToString(reader["price"]);
                    view_price.Text = p_id;
                }

                if (category.SelectedIndex == 3)
                {
                    MessageBox.Show("You have selected size 14*");
                    string query = "SELECT * FROM brands_t WHERE size='14' AND brand= '" + item_b + "' AND  s_id = " + suplierId.Text;

                    SqlCommand select_sup = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader reader = select_sup.ExecuteReader();
                    reader.Read();

                    string p_id = Convert.ToString(reader["price"]);
                    view_price.Text = p_id;
                }

                if (category.SelectedIndex == 4)
                {
                    MessageBox.Show("You have selected size 17*");
                    string query = "SELECT * FROM brands_t WHERE size='17' AND brand= '" + item_b + "' AND  s_id = " + suplierId.Text;

                    SqlCommand select_sup = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader reader = select_sup.ExecuteReader();
                    reader.Read();

                    string p_id = Convert.ToString(reader["price"]);
                    view_price.Text = p_id;
                }

                if (category.SelectedIndex == 5)
                {
                    MessageBox.Show("You have selected size 42*");

                    string query = "SELECT * FROM brands_t WHERE size='42' AND brand= '" + item_b + "' AND  s_id = " + suplierId.Text;

                    SqlCommand select_sup = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader reader = select_sup.ExecuteReader();
                    reader.Read();

                    string p_id = Convert.ToString(reader["price"]);
                    view_price.Text = p_id;
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, New tier size for the above brand");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            add_stock add = new add_stock();
            add.Show();
        }
    }
    
}
