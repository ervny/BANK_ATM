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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using ViewChanger.Views;
using System.IO;


namespace ViewChanger.Views
{
    /// <summary>
    /// Interaction logic for RedView.xaml
    /// </summary>
    public partial class RedView : UserControl
    {
        public RedView()
        {
            InitializeComponent();
        }


        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!(tbx_amount_add.Text == ""))
            {
                string frmjson = File.ReadAllText(@"Current.json");
                Users u2 = JsonConvert.DeserializeObject<Users>(frmjson);
                try
                {
                    u2.amount += Convert.ToDouble(tbx_amount_add.Text);
                }
                catch(Exception eexe)
                { 
                }

                string tojson = JsonConvert.SerializeObject(u2);
                File.WriteAllText(@"Current.json", tojson);


                frmjson = File.ReadAllText(@"Users.json");
                List<Users> list = JsonConvert.DeserializeObject<List<Users>>(frmjson);

                foreach (Users users in list)
                {

                    if (users.username == u2.username && users.password == u2.password)
                    {

                        list.Remove(users);
                        break;

                    }

                }
                list.Add(u2);
                u2.WriteToJson(list);





                ClearIt();
            }
            else
            {
                ClearIt();
            }



        }
        public void ClearIt()
        {
            tbx_amount_add.Text = "";
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearIt();
        }

        public void populate()
        { 

        }
    }
}
