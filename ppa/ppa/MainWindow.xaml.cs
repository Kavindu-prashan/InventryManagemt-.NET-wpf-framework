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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ppa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int state;
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6646GLP\SQLEXPRESS;Initial Catalog=ppa;Integrated Security=True;");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            manager man = new manager();
            man.Show();
        }
       

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (validate_user(user.Text, pass.Password) == 1)
            {
                // MessageBox.Show("manager");
                manager man = new manager();
                man.Show();
                user.Clear();
                pass.Clear();
            }
            else if (validate_user(user.Text, pass.Password) == 2)
            {
                // MessageBox.Show("receptionist");
                admin ad = new admin();
                ad.Show();
                user.Clear();
                pass.Clear();
            }

            
            else if (validate_user(user.Text, pass.Password) == 5)
            {
                MessageBox.Show("Please enter valid credentials");
                user.Clear();
                pass.Clear();
            }
        }

        public int validate_user(string username, string password)
        {
 
                state = 5;
                string valid = "SELECT * FROM login_tb WHERE username = '" + username + "' AND password = '" + password + "'";

                connect.Open();
                SqlCommand validate = new SqlCommand(valid, connect);
                SqlDataReader get_state = validate.ExecuteReader();

                while (get_state.Read())
                {
                    state = Convert.ToInt32(get_state["state"]);
                }
                connect.Close();
                if (state != 0) { return state; }
                int invalid = 5;
                return invalid;

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window1 v = new Window1();
            v.Show();
        }
    }
}
