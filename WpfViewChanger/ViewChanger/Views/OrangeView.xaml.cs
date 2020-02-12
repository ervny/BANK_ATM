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
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace ViewChanger.Views
{
    /// <summary>
    /// Interaction logic for OrangeView.xaml
    /// </summary>
    public partial class OrangeView : UserControl
    {

        //DataTable dt;

        public OrangeView()
        {
            InitializeComponent();
          

        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            string frmjson = File.ReadAllText(@"Current.json");
            Users u = JsonConvert.DeserializeObject<Users>(frmjson);


            double towid = Convert.ToDouble(tbx_amount_rem.Text);
            if (u.amount < towid)
            {
                msg_pane.Content = "INVALID REQUEST AMOUNT IS LESS ";
            }
            else
            {
                if (towid > 20000)
                {
                    msg_pane.Content = "GRATER THAN 20000 PLS ENTER LESS";
                }
                else if ( towid % 100 !=0)
                {
                    msg_pane.Content = "NOT A VALID AMOUNT TO WITHDRAW";
                }
                else
                {

                    u.amount = u.amount - towid;
                    int[] currency = { 2000, 500, 200, 100 };
                    double temp = towid;
                    string op = "";
                    int[] outcur = { 0, 0, 0, 0 };
                    int i = 0;
                    while (i <= 3)
                    {


                        while (temp >= currency[i])
                        {
                            outcur[i] += 1;
                            temp = temp - currency[i];
                        }
                        i++;
                    }

                    op = "{ 2000 * " + Convert.ToSingle(outcur[0]) + "}      {500 * " + Convert.ToSingle(outcur[1]) + "}      {200 *" + Convert.ToSingle(outcur[2]) + "}    { 100  * " + Convert.ToSingle(outcur[3]) + " }";
                    msg_pane.Content = op;

                    string tojson = JsonConvert.SerializeObject(u);
                    File.WriteAllText(@"Current.json", tojson);


                    frmjson = File.ReadAllText(@"Users.json");
                    List<Users> list = JsonConvert.DeserializeObject<List<Users>>(frmjson);
                   
                    foreach (Users users in list)
                    {

                        if (users.username == u.username && users.password == u.password)
                        {

                            list.Remove(users);
                            break;

                        }

                    }
                    list.Add(u);
                    u.WriteToJson(list);
                }


            }



        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            tbx_amount_rem.Text = "";

        }

        /*
        public void display()
        {

            string frmjson = File.ReadAllText(@"Students.json");
            List<Students> l2 = JsonConvert.DeserializeObject<List<Students>>(frmjson);
            datagrid.ItemsSource = l2;
            datagrid.AutoGenerateColumns = true;

        }*/
    }
}
