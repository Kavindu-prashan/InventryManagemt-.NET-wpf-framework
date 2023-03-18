using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for addsuplier.xaml
    /// </summary> 
    public partial class addsuplier : Window
    {
        public addsuplier()
        {
            InitializeComponent();

            category.Items.Add("10*");
            category.Items.Add("13*");
            category.Items.Add("13.5*");
            category.Items.Add("14*");
            category.Items.Add("17");
            category.Items.Add("42");
     

            category.SelectedIndex = -1;
        }

       // int item_role;
        double item_size;
        int item_brand1;
        int item_brand2;
        int item_brand3;
        int item_brand4;

        int item_brand;
        string sup_id;
        int brand_price;

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

        private void Button_Click(object sender, RoutedEventArgs e)
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
           
            if(first_combo.IsChecked==true)
            {
                brand_price = 1;
                item_brand1 =1;
                item_brand = 1;
            }
            else if(second_combo.IsChecked==true)
            {
                item_brand2 = 1;
                brand_price = 2;
                item_brand = 2;
            }
            else if(third_combo.IsChecked==true)
            {
                item_brand3 = 1;
                brand_price = 3;
                item_brand = 3;
            }
            else if(fourth_combo.IsChecked==true)
            {
                item_brand4 = 1;
                brand_price = 4;
                item_brand = 4;
            }
            if ((EmailIsValid(email_txt.Text)))
            {
                MessageBox.Show("Enter valid email address, or existing suplier !! ");
                email_txt.Clear();
            }
            string digits = Convert.ToString(contact_txt.Text);
            int con_digits = digits.ToString().Length;
            if (con_digits == 10)
            { 
               if ((category.SelectedIndex == 0) || (category.SelectedIndex == 1) || (category.SelectedIndex == 2) || (category.SelectedIndex == 3) || (category.SelectedIndex == 4) || (category.SelectedIndex == 5))
                {


                    if ((first_combo.IsChecked == true) || (second_combo.IsChecked == true) || (third_combo.IsChecked == true) || (fourth_combo.IsChecked == true))
                    {
                        if ((name_txt.Text == "") || (contact_txt.Text == "") || (email_txt.Text == "") || (qty.Text == "")||(price_txt.Text==""))
                        {
                            MessageBox.Show("Error Fill All details");
                        }
                        //else
                        {
                            try
                            {
                                SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


                                string query = "INSERT INTO suplier_t ( name,contact,email,brand1,brand2,brand3,brand4) VALUES('" + name_txt.Text + "','" + contact_txt.Text + "','" + email_txt.Text + "','" + item_brand1 + "','" + item_brand2 + "','" + item_brand3 + "','" + item_brand4 + "')";
                                SqlCommand cmd_2 = new SqlCommand(query, connect);
                                connect.Open();
                                cmd_2.ExecuteNonQuery();
                                connect.Close();

                                try
                                {


                                    string shw_sid_query = "SELECT * FROM suplier_t";
                                    SqlCommand shw_sid_cmd = new SqlCommand(shw_sid_query, connect);
                                    connect.Open();
                                    SqlDataReader read_sid = shw_sid_cmd.ExecuteReader();

                                    while (read_sid.Read())
                                    {
                                        sup_id = Convert.ToString(read_sid["s_id"]);
                                    }

                                    show_id.Text = sup_id;

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error with loding ID");
                                }


                                SqlConnection connect_1 = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                                string query1 = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + show_id.Text + "','" + item_brand + "','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";

                                SqlCommand cmd_3 = new SqlCommand(query1, connect_1);
                                connect_1.Open();
                                cmd_3.ExecuteNonQuery();
                                connect.Close();


                                    try//add price
                                    {
                                        SqlConnection connect_2 = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                                        if (category.SelectedIndex == 0)
                                        {
                                            string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','" + price_txt.Text + "','0','0','0','0','0')";
                                            SqlCommand cmd_price = new SqlCommand(query_price, connect_2);
                                            connect_2.Open();
                                            cmd_price.ExecuteNonQuery();
                                            connect_2.Close();
                                        }
                                        else if (category.SelectedIndex == 1)
                                        {
                                            string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','" + price_txt.Text + "','0','0','0','0')";
                                            SqlCommand cmd_price = new SqlCommand(query_price, connect_2);
                                            connect_2.Open();
                                            cmd_price.ExecuteNonQuery();
                                            connect_2.Close();

                                        }

                                        else if (category.SelectedIndex == 2)
                                        {
                                            string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','" + price_txt.Text + "','0','0','0')";
                                            SqlCommand cmd_price = new SqlCommand(query_price, connect_2);
                                            connect_2.Open();
                                            cmd_price.ExecuteNonQuery();
                                            connect_2.Close();

                                        }
                                        else if (category.SelectedIndex == 3)
                                        {
                                            string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','0','" + price_txt.Text + "','0','0')";
                                            SqlCommand cmd_price = new SqlCommand(query_price, connect_2);
                                            connect_2.Open();
                                            cmd_price.ExecuteNonQuery();
                                            connect_2.Close();

                                        }
                                        else if (category.SelectedIndex == 4)
                                        {
                                            string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','0','0','" + price_txt.Text + "','0')";
                                            SqlCommand cmd_price = new SqlCommand(query_price, connect_2);
                                            connect_2.Open();
                                            cmd_price.ExecuteNonQuery();
                                            connect_2.Close();

                                        }

                                        else if (category.SelectedIndex == 5)
                                        {
                                            string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','0','0','0','" + price_txt.Text + "')";
                                            SqlCommand cmd_price = new SqlCommand(query_price, connect_2);
                                            connect_2.Open();
                                            cmd_price.ExecuteNonQuery();
                                            connect_2.Close();

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error in inserting the price");
                                    }


                                try
                                {
                                    //string query1 = "INSERT INTO brands_t( s_id,size,qty,brand1,brand2,brand3,brand4) VALUES('" + show_id.Text + "','" + item_size + "','" + qty.Text + "','" + item_brand1 + "','" + item_brand2 + "','" + item_brand3 + "','" + item_brand4 + "')";


                                   // name_txt.Clear();
                                    contact_txt.Clear();
                                    email_txt.Clear();
                                    price_txt.Clear();
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

                                    MessageBox.Show("Entered values are uploaded");
                                    email_txt.Clear();
                                    price_txt.Clear();
                                    qty.Clear();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error ??");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error !!!");
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
     
            }
            else
            {
                MessageBox.Show("Please Enter the correct contact Number");
                contact_txt.Clear();
            }
            


        }

        private bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (category.SelectedIndex == 0)
                {
                    MessageBox.Show("You have selected size 10*");
                }
                if (category.SelectedIndex == 1)
                {
                    MessageBox.Show("You have selected size 13*");
                }
                if (category.SelectedIndex == 2)
                {
                    MessageBox.Show("You have selected size 13.5*");
                }
                if (category.SelectedIndex == 3)
                {
                    MessageBox.Show("You have selected size 14*");
                }
                if (category.SelectedIndex == 4)
                {
                    MessageBox.Show("You have selected size 17*");
                }
                if (category.SelectedIndex == 5)
                {
                    MessageBox.Show("You have selected size 42*");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error ###");
            }
        }

        private void show_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query1 = "SELECT * FROM suplier_t WHERE s_id =" + show_id.Text;
            SqlCommand cmd_3 = new SqlCommand(query1, connect);
            connect.Open();
            SqlDataReader reader_1 = cmd_3.ExecuteReader();

            reader_1.Read();

            string name = Convert.ToString(reader_1["name"]);
            string contact = Convert.ToString(reader_1["contact"]);
            string email = Convert.ToString(reader_1["email"]);
            string size = Convert.ToString(reader_1["size"]);
            string qty = Convert.ToString(reader_1["qty"]);
            string brand_1 = Convert.ToString(reader_1["brand1"]);
            string brand_2 = Convert.ToString(reader_1["brand2"]);
            string brand_3 = Convert.ToString(reader_1["brand3"]);
            string brand_4 = Convert.ToString(reader_1["brand4"]);

            name_txt.Text = name;
            contact_txt.Text = contact;
            email_txt.Text = email;

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (show_id.Text == "")
            {
                MessageBox.Show("Can't update, new suplier");
            }
            else
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
                  // brand selection
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
                        if ((name_txt.Text == "") || (qty.Text == "")||(price_txt.Text==""))
                        {
                            MessageBox.Show("Error,fill all details");
                        }
                        else
                        {
                            try
                            {
                                SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                                if (first_combo.IsChecked == true)
                                {
                                    //string query_one = "INSERT INTO brands_t( s_id,size,qty,brand1,brand2,brand3,brand4) VALUES('" + show_id.Text + "','" + item_size + "','" + qty.Text + "','" + item_brand1 + "','0','0','0')";
                                    string query_one = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + show_id.Text + "','" + item_brand + "','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";

                                    string query_one_update = "UPDATE suplier_t set brand1= brand1 + '1' WHERE s_id='"+show_id.Text+"'";

                                    SqlCommand cmd_one_update = new SqlCommand(query_one_update, connect);
                                    SqlCommand cmd_one = new SqlCommand(query_one, connect);

                                    connect.Open();
                                    cmd_one.ExecuteNonQuery();
                                    cmd_one_update.ExecuteNonQuery();
                                    connect.Close();
                                }

                                else if (second_combo.IsChecked == true)
                                {
                                    //string query_two = "INSERT INTO brands_t( s_id,size,qty,brand1,brand2,brand3,brand4) VALUES('" + show_id.Text + "','" + item_size + "','" + qty.Text + "','0','" + item_brand2 + "','0','0')";
                                    string query_two = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + show_id.Text + "','" + item_brand + "','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";
                                    string query_two_update = "UPDATE suplier_t set brand2= brand2 + '1' WHERE s_id='" + show_id.Text + "'";
                                    SqlCommand cmd_two_update = new SqlCommand(query_two_update, connect);
                                    SqlCommand cmd_two = new SqlCommand(query_two, connect);

                                    connect.Open();
                                    cmd_two_update.ExecuteNonQuery();
                                    cmd_two.ExecuteNonQuery();
                                connect.Close();
                                }
                                else if (third_combo.IsChecked == true)
                                {
                                   // string query_three = "INSERT INTO brands_t( s_id,size,qty,brand1,brand2,brand3,brand4) VALUES('" + show_id.Text + "','" + item_size + "','" + qty.Text + "','0','0','" + item_brand3 + "','0')";
                                    string query_three = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + show_id.Text + "','" + item_brand + "','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";
                                    string query_three_update = "UPDATE suplier_t set brand3= brand3 + '1' WHERE s_id='" + show_id.Text + "'";
                                    SqlCommand cmd_three_update = new SqlCommand(query_three_update, connect);
                                    SqlCommand cmd_three = new SqlCommand(query_three, connect);

                                    connect.Open();
                                    cmd_three_update.ExecuteNonQuery();
                                    cmd_three.ExecuteNonQuery();
                                }
                                else if (fourth_combo.IsChecked == true)
                                {
                                    //string query_four = "INSERT INTO brands_t( s_id,size,qty,brand1,brand2,brand3,brand4) VALUES('" + show_id.Text + "','" + item_size + "','" + qty.Text + "','0','0','0','" + item_brand4 + "')";
                                    string query_four = "INSERT INTO brands_t( s_id,brand,size,price,qty) VALUES('" + show_id.Text + "','" + item_brand + "','" + item_size + "','" + price_txt.Text + "','" + qty.Text + "')";
                                    string query_four_update = "UPDATE suplier_t set brand4= brand4 + '1' WHERE s_id='" + show_id.Text + "'";
                                    SqlCommand cmd_four_update = new SqlCommand(query_four_update, connect);

                                    SqlCommand cmd_four = new SqlCommand(query_four, connect);

                                    connect.Open();
                                    cmd_four_update.ExecuteNonQuery();
                                    cmd_four.ExecuteNonQuery();
                                    connect.Close();
                                }


                                try//add price
                                {
                                    if (category.SelectedIndex == 0)
                                    {
                                        string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','" + price_txt.Text + "','0','0','0','0','0')";
                                        SqlCommand cmd_price = new SqlCommand(query_price, connect);
                                        connect.Open();
                                        cmd_price.ExecuteNonQuery();
                                        connect.Close();
                                    }
                                    else if (category.SelectedIndex == 1)
                                    {
                                        string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','" + price_txt.Text + "','0','0','0','0')";
                                        SqlCommand cmd_price = new SqlCommand(query_price, connect);
                                        connect.Open();
                                        cmd_price.ExecuteNonQuery();
                                        connect.Close();

                                    }

                                    else if (category.SelectedIndex == 2)
                                    {
                                        string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','" + price_txt.Text + "','0','0','0')";
                                        SqlCommand cmd_price = new SqlCommand(query_price, connect);
                                        connect.Open();
                                        cmd_price.ExecuteNonQuery();
                                        connect.Close();

                                    }
                                    else if (category.SelectedIndex == 3)
                                    {
                                        string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','0','" + price_txt.Text + "','0','0')";
                                        SqlCommand cmd_price = new SqlCommand(query_price, connect);
                                        connect.Open();
                                        cmd_price.ExecuteNonQuery();
                                        connect.Close();

                                    }
                                    else if (category.SelectedIndex == 4)
                                    {
                                        string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','0','0','" + price_txt.Text + "','0')";
                                        SqlCommand cmd_price = new SqlCommand(query_price, connect);
                                        connect.Open();
                                        cmd_price.ExecuteNonQuery();
                                        connect.Close();

                                    }

                                    else if (category.SelectedIndex == 5)
                                    {
                                        string query_price = "INSERT INTO price_t ( brand,size1,size2,size3,size4,size5,size6) VALUES ('" + brand_price + "','0','0','0','0','0','" + price_txt.Text + "')";
                                        SqlCommand cmd_price = new SqlCommand(query_price, connect);
                                        connect.Open();
                                        cmd_price.ExecuteNonQuery();
                                        connect.Close();

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error in inserting the price");
                                }





                                qty.Clear();
                                price_txt.Clear();

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
            }
        }
    }



}
