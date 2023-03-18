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
    /// Interaction logic for new_customer.xaml
    /// </summary>
    public partial class new_customer : Window

    {




        public new_customer()
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

        int item_brand;

        double item_size;
        string cus_id;

        string price_id;
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (category.SelectedIndex == 0)
            {
                item_size = 10;
               // show_size.Text = "10";

            }
            else if (category.SelectedIndex == 1)
            {
                item_size = 13;
               // show_size.Text = "13";
            }
            else if (category.SelectedIndex == 2)
            {
                item_size = 13.5;
               // show_size.Text = "13.5";
            }
            else if (category.SelectedIndex == 3)
            {
                item_size = 14;
               // show_size.Text = "14";
            }

            else if (category.SelectedIndex == 4)
            {
                item_size = 17;
               // show_size.Text = "17";
            }
            else if (category.SelectedIndex == 5)
            {

                item_size = 42;
               // show_size.Text = "42";
            }
            if (first_combo.IsChecked == true)
            {
                item_brand = 1;
               // show_brand.Text = "1";
            }
            else if (second_combo.IsChecked == true)
            {
                item_brand = 2;
               // show_brand.Text = "2";

            }
            else if (third_combo.IsChecked == true)
            {
                item_brand = 3;
               // show_brand.Text = "3";

            }
            else if (fourth_combo.IsChecked == true)
            {
                item_brand = 4;
               // show_brand.Text = "4";

            }

            if (show_id.Text == "")
            {
                string digits = Convert.ToString(contact_txt.Text);
                int con_digits = digits.ToString().Length;
                if (con_digits == 10)

                {

                    if ((category.SelectedIndex == 0) || (category.SelectedIndex == 1) || (category.SelectedIndex == 2) || (category.SelectedIndex == 3) || (category.SelectedIndex == 4) || (category.SelectedIndex == 5))
                    {


                        if ((first_combo.IsChecked == true) || (second_combo.IsChecked == true) || (third_combo.IsChecked == true) || (fourth_combo.IsChecked == true))
                        {
                            if ((name_txt.Text == "") || (contact_txt.Text == "") || (vehicle_nub.Text == "") || (qty.Text == ""))
                            {
                                MessageBox.Show("Error Fill All Details ");
                            }
                            else
                            {


                                try
                                {


                                    try
                                    {
                                        string query = "INSERT INTO customer_t ( name,contact,brand,size,qty) VALUES('" + name_txt.Text + "','" + contact_txt.Text + "','','','')";
                                        SqlCommand cmd_2 = new SqlCommand(query,connect);
                                        connect.Open();
                                        cmd_2.ExecuteNonQuery();
                                        connect.Close();



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error with Customer data entering");
                                    }




                                    try
                                    {
                                        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                                        if (first_combo.IsChecked == true)
                                        {
                                            string query_1 = "UPDATE brands_t set qty= qty - '" + qty.Text + "'  WHERE brand ='1' AND size='" + item_size + "' ";

                                            SqlCommand cmd_1 = new SqlCommand(query_1,connect);

                                            connect.Open();
                                            cmd_1.ExecuteNonQuery();
                                            connect.Close();
                                        }

                                        else if (second_combo.IsChecked == true)
                                        {
                                            string query_2 = "UPDATE brands_t set qty=qty - '" + qty.Text + "' WHERE brand ='2' AND size='" + item_size + "'";

                                            SqlCommand cmd_4 = new SqlCommand(query_2,connect);

                                            connect.Open();
                                            cmd_4.ExecuteNonQuery();
                                            connect.Close();
                                        }
                                        else if (third_combo.IsChecked == true)
                                        {
                                            string query_3 = "UPDATE brands_t set qty=qty - '" + qty.Text + "' WHERE brand ='3' AND size='" + item_size + "'";

                                            SqlCommand cmd_3 = new SqlCommand(query_3,connect);

                                            connect.Open();
                                            cmd_3.ExecuteNonQuery();
                                            connect.Close();
                                        }
                                        else if (fourth_combo.IsChecked == true)
                                        {
                                            string query_4 = "UPDATE brands_t set qty=qty - '" + qty.Text + "' WHERE brand ='4' AND size='" + item_size + "'";

                                            SqlCommand cmd_4 = new SqlCommand(query_4,connect);

                                            connect.Open();
                                            cmd_4.ExecuteNonQuery();
                                            connect.Close();
                                        }

                                        try
                                        {
                                            SqlConnection connect_1 = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                                                string query_b_p = "SELECT * FROM brands_t WHERE size='" + item_size + "' AND brand =" + item_brand;
                                                SqlCommand cmd_b_p = new SqlCommand(query_b_p,connect_1);
                                                connect_1.Open();
                                                SqlDataReader reader_b_p = cmd_b_p.ExecuteReader();

                                                reader_b_p.Read();

                                                string itm_pri = Convert.ToString(reader_b_p["price"]);

                             
                                                int fp = int.Parse(itm_pri);
                                                int fpqty = int.Parse(qty.Text);
                                                int fullp = (fp * fpqty);

                                            if (fullp==0)
                                            {
                                                item_price.Text = "0";

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



                                            }
                                                item_prices.Text = Convert.ToString(fullp);
                                                item_price.Text = Convert.ToString(fullp);


                                              


                                                qty_list.Text = qty.Text;

                                                qty.Clear();


                                 

                                                if (category.SelectedIndex == 0)
                                                {
                                                    show_size.Text = "10";

                                                }
                                                else if (category.SelectedIndex == 1)
                                                {
                                                    show_size.Text = "13";
                                                }
                                                else if (category.SelectedIndex == 2)
                                                {
                                                    show_size.Text = "13.5";
                                                }
                                                else if (category.SelectedIndex == 3)
                                                {
                                                    show_size.Text = "14";
                                                }

                                                else if (category.SelectedIndex == 4)
                                                {
                                                    show_size.Text = "17";
                                                }
                                                else if (category.SelectedIndex == 5)
                                                {

                                                    show_size.Text = "42";
                                                }
                                                if (first_combo.IsChecked == true)
                                                {
                                                    show_brand.Text = "1";
                                                }
                                                else if (second_combo.IsChecked == true)
                                                {
                                                    show_brand.Text = "2";

                                                }
                                                else if (third_combo.IsChecked == true)
                                                {
                                                    show_brand.Text = "3";

                                                }
                                                else if (fourth_combo.IsChecked == true)
                                                {
                                                    show_brand.Text = "4";

                                                }



                                                       



                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error with loding price");



                                        }


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

                                        MessageBoxResult m = MessageBox.Show("Do you want to add another transcaction ?","",MessageBoxButton.YesNo);
                                        if (m == MessageBoxResult.Yes)
                                        {
                                            price_test.Clear();
                                            show_brand.Clear();
                                            show_size.Clear();



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
                                                show_brand.Clear();
                                                show_size.Clear();
                                            }




                                        }
                                        else
                                        {
                                            reg.IsEnabled = false;



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



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error !!");

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error ??");

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
            else  //Another item
            {
                try
                {



                    SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                    if (first_combo.IsChecked == true)
                    {
                        string query_1 = "UPDATE brands_t set qty= qty - '" + qty.Text + "'  WHERE brand ='1' AND size='" + item_size + "' ";

                        SqlCommand cmd_1 = new SqlCommand(query_1,connect);

                        connect.Open();
                        cmd_1.ExecuteNonQuery();
                        connect.Close();
                    }

                    else if (second_combo.IsChecked == true)
                    {
                        string query_2 = "UPDATE brands_t set qty=qty - '" + qty.Text + "' WHERE brand ='2' AND size='" + item_size + "'";

                        SqlCommand cmd_4 = new SqlCommand(query_2,connect);

                        connect.Open();
                        cmd_4.ExecuteNonQuery();
                        connect.Close();
                    }
                    else if (third_combo.IsChecked == true)
                    {
                        string query_3 = "UPDATE brands_t set qty=qty - '" + qty.Text + "' WHERE brand ='3' AND size='" + item_size + "'";

                        SqlCommand cmd_3 = new SqlCommand(query_3,connect);

                        connect.Open();
                        cmd_3.ExecuteNonQuery();
                        connect.Close();
                    }
                    else if (fourth_combo.IsChecked == true)
                    {
                        string query_4 = "UPDATE brands_t set qty=qty - '" + qty.Text + "' WHERE brand ='4' AND size='" + item_size + "'";

                        SqlCommand cmd_4 = new SqlCommand(query_4,connect);

                        connect.Open();
                        cmd_4.ExecuteNonQuery();
                        connect.Close();
                    }

                    try
                    {
                        SqlConnection connect_1 = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");

                        string query_b_p = "SELECT * FROM brands_t WHERE size='" + item_size + "' AND brand =" + item_brand;
                        SqlCommand cmd_b_p = new SqlCommand(query_b_p,connect_1);
                        connect_1.Open();
                        SqlDataReader reader_b_p = cmd_b_p.ExecuteReader();

                        reader_b_p.Read();

                        string itm_pri = Convert.ToString(reader_b_p["price"]);



                        int fp = int.Parse(itm_pri);
                        int fpqty = int.Parse(qty.Text);
                        int fullp = (fp * fpqty);

                


                        price_test.Text = Convert.ToString(fullp);
                        int price_txt = int.Parse(price_test.Text);

                        item_prices.Text = item_prices.Text +","+ price_txt;
                  
                        qty_list.Text = qty_list.Text + "  " + qty.Text;
                        qty.Clear();



                        if (price_test.Text != "")
                        {

                            if (category.SelectedIndex == 0)
                            {
                                show_size.Text = "10";

                            }
                            else if (category.SelectedIndex == 1)
                            {
                                show_size.Text = "13";
                            }
                            else if (category.SelectedIndex == 2)
                            {
                                show_size.Text = "13.5";
                            }
                            else if (category.SelectedIndex == 3)
                            {
                                show_size.Text = "14";
                            }

                            else if (category.SelectedIndex == 4)
                            {
                                show_size.Text = "17";
                            }
                            else if (category.SelectedIndex == 5)
                            {

                                show_size.Text = "42";
                            }
                            if (first_combo.IsChecked == true)
                            {
                                show_brand.Text = "1";
                            }
                            else if (second_combo.IsChecked == true)
                            {
                                show_brand.Text = "2";

                            }
                            else if (third_combo.IsChecked == true)
                            {
                                show_brand.Text = "3";

                            }
                            else if (fourth_combo.IsChecked == true)
                            {
                                show_brand.Text = "4";

                            }



                        }





                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Error with loding price");
                        show_brand.Clear();
                        show_size.Clear();


                    }

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

                    MessageBoxResult m = MessageBox.Show("Do you want to add another transcaction ?","",MessageBoxButton.YesNo);
                    if (m == MessageBoxResult.Yes)
                    {
                      price_test.Clear();
                      show_brand.Clear();
                      show_size.Clear();




                    }
                    else
                    {
                        reg.IsEnabled = false;
                        

                    }
                }
                catch (Exception ex)
                {

                }
            }

            
        }

        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void show_id_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");



            if ((chk_Gtotal.Text==""))
            {
                MessageBox.Show("There's no entry");
            }
            else
            {

                try
                {
                    SqlConnection connect_1 = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRES; Initial Catalog=ppa; Integrated Security=SSPI;");


                    string query_1 = "UPDATE customer_t set size='" + sizes.Text + "' WHERE c_id='" + show_id.Text + "' ";
                    SqlCommand cmd_1 = new SqlCommand(query_1,connect_1);
                    connect_1.Open();
                    cmd_1.ExecuteNonQuery();
                    connect_1.Close();

                    string query_2 = "UPDATE customer_t set brand='" + Brands.Text + "' WHERE c_id='" + show_id.Text + "' ";
                    SqlCommand cmd_2 = new SqlCommand(query_2,connect_1);
                    connect_1.Open();
                    cmd_2.ExecuteNonQuery();
                    connect_1.Close();

                    string query_3 = "UPDATE customer_t set qty='" + qty_list.Text + "' WHERE c_id='" + show_id.Text + "' ";
                    SqlCommand cmd_3 = new SqlCommand(query_3,connect_1);
                    connect_1.Open();
                    cmd_3.ExecuteNonQuery();
                    connect_1.Close();




                }
                    catch (Exception ex)
                {
                    MessageBox.Show("Error with updating coustomer data");
                }



                try
                {

                    string query_sale = "INSERT INTO sales_t ( c_id,brand,size,qty,date,price,dis) VALUES('" + show_id.Text + "','" + Brands.Text + "','" + sizes.Text + "','" + qty_list.Text + "','" + DateTime.Today + "','" + chk_Gtotal.Text + "','"+ discount_txt.Text+ "')";
                    SqlCommand cmd_sale = new SqlCommand(query_sale, connect);
                    connect.Open();
                    cmd_sale.ExecuteNonQuery();
                    connect.Close();

                    MessageBox.Show("Transaction Done");
                    bill bil = new bill();
                    bil.Show();
                }
                        catch (Exception ex)
                {
                    MessageBox.Show("Error with transaction");
                }
        }

        }

        private void discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (discount_txt.Text == "")
                {
                chk_Gtotal.Text = item_price.Text;
                }
            else
                {
                try
                    {
                    int brand_price, discount, total;

                    brand_price = int.Parse(item_price.Text);
                    discount = int.Parse(discount_txt.Text);
                    total = (brand_price - discount);
                    chk_Gtotal.Text = Convert.ToString(total);
                    }
                catch (Exception ex)
                    {

                    }
                }
        }

        private void item_price_TextChanged(object sender,TextChangedEventArgs e)
         {



        }




        private void price_test_TextChanged(object sender,TextChangedEventArgs e)
        {   if (item_price.Text == "")
            {
                item_price.Text = price_test.Text;
            }
            else
            {
                try
                {
                    int item_p, item_p1, full;
                    item_p = int.Parse(price_test.Text);
                    item_p1 = int.Parse(item_price.Text);
                    full = item_p + item_p1;
                    item_price.Text = Convert.ToString(full);

                }
                catch (Exception ex)
                {
                    // price_test.Clear();
                }
            }
        }

        private void show_brand_TextChanged(object sender,TextChangedEventArgs e)
        {

                try
                {
                    int b = int.Parse(show_brand.Text);
                    Brands.Text = Brands.Text + "   " + b;
                }
                catch (Exception ex)
                {

                }
            

        }

        private void show_size_TextChanged(object sender,TextChangedEventArgs e)
        {

                try
                {
                    int p = int.Parse(show_size.Text);
                    sizes.Text = sizes.Text + "   " + p;
                }
                catch (Exception ex)
                {

                }
            
        }

        private void listView_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {

        }
    }
    
}
