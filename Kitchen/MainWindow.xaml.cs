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

namespace Kitchen
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Service.CounterServerService Counter = new Service.CounterServerService();



     


        public MainWindow()
        {
            Service.KitchenConnection.Instance.Start();
            InitializeComponent();
      
            /*var service = new Service.Class1();
            service.TestDataBase();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service.KitchenConnection.Instance.Send("testdddddddd");
        }
    }
}
