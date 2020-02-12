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
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace ViewChanger.Views
{
    /// <summary>
    /// Interaction logic for BlueView.xaml
    /// </summary>
    public partial class BlueView : UserControl
    {
        public BlueView()
        {
            InitializeComponent();
        }

        private void show_amount_Click(object sender, RoutedEventArgs e)
        {
            string frmjson = File.ReadAllText(@"Current.json");
            Users u2 = JsonConvert.DeserializeObject<Users>(frmjson);
            current_username.Text = Convert.ToString(u2.amount);

           

        }
    }
}
