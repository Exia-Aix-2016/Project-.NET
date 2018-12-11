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
using Model;

namespace Kitchen
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Model.IRender<Model.Kitchen>
    {
        public MainWindow()
        {
            Service.KitchenConnection.Instance.Start();
            InitializeComponent();
      
            /*var service = new Service.Class1();
            service.TestDataBase();*/
        }

        public void Render(Model.Kitchen obj)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Meal[] meals = new Model.Meal[2];

            /*meals[0] = new Model.Meal("Test");
            meals[1] = new Model.Meal("Bla");
            Model.MessageSocket  msg = new Model.MessageSocket(meals);
            Service.KitchenConnection.Instance.Send(msg);*/
        }
    }
}
