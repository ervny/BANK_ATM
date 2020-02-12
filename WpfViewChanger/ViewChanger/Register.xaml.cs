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
using System.IO;
using Newtonsoft.Json;



namespace ViewChanger
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (!(tbx_reg_username.Text == "" || tbx_reg_password.Text==""))
            {
                Users s1 = new Users
                {
                    username = tbx_reg_username.Text,
                    password = tbx_reg_password.Text,
                    amount = Convert.ToDouble(tbx_reg_amount.Text)
                

                };

                string res = s1.WriteToJson(s1);
                ClearIt();
            }
            else
            {
                ClearIt();
            }



        }

        public void ClearIt()
        {
            tbx_reg_username.Text = "";
            tbx_reg_password.Text = "";
            tbx_reg_amount.Text = "";

        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearIt();

        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}
