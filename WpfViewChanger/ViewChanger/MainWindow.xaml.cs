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
using ViewChanger.ViewModels;

namespace ViewChanger
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RedView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RedViewModel();
            lbl_status.Content = "Add Clicked";
        }

        private void BlueView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BlueViewModel();
            lbl_status.Content = "View Clicked";
        }

        private void OrangeView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new OrangeViewModel();
            lbl_status.Content = "Withdraw Clicked";
        }
    }
}
