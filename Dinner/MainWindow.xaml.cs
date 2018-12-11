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
using Service;
using Model;

namespace Dinner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRender<DiningRoom>
    {
        private SimulationController simulationController;

        public MainWindow()
        {
            //DinnerConnection.Instance.Start();

            InitializeComponent();

            simulationController = new SimulationController(Render);
        }

        public void Render(DiningRoom diningRoom)
        {

        }
    }
}
