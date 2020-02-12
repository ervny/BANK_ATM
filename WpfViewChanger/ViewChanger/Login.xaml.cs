using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;
using System.IO;

namespace ViewChanger
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            string u=tbx_username.Text;
            string p=pbx_password.Password;

            Users curr=null;
            if (tbx_username.Text == "admin" && pbx_password.Password == "admin")
            {
                flag = false;
            }
            else {

                string frmjson = File.ReadAllText(@"Users.json");
                List<Users> list = JsonConvert.DeserializeObject<List<Users>>(frmjson);
               
                foreach (Users users in list)
                {

                    if(users.username==u && users.password==p)
                    {
                        curr = users;
                        flag = true;
                        break;

                    }


                    
                }


            }

            if (flag)
            {


                MainWindow mainWindow = new MainWindow();


                    string tojson = JsonConvert.SerializeObject(curr);
                    File.WriteAllText(@"Current.json", tojson);
                

                mainWindow.Show();
                Close();

            }
            else
            {

                tbx_username.Text = "";

                pbx_password.Password = "";


            }

        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Close();
        }
    }
}
