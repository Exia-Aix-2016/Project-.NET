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
using System.Data;

namespace Dinner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRender<DiningRoom>
    {
        private SimulationController simulationController;
        private DataTable data;
        public MainWindow()
        {
            //DinnerConnection.Instance.Start();

            InitializeComponent();

            simulationController = new SimulationController(Render);
            data = new DataTable();
            data.Columns.Add("Table", typeof(string));
            data.Columns.Add("Numbers Of Client", typeof(int));
            data.Columns.Add("Status", typeof(string));

            data.Rows.Add("Table 1", 10, Model.TableStatus.CHOOSEN.ToString());


        }

        public void Render(DiningRoom diningRoom)
        {
            this.NumberClient.Content = $"Number of client : {diningRoom.Lobby.Count}";

        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {
            simulationController.Start();
        }


        private void StopSimbutton_Click(object sender, RoutedEventArgs e)
        {
            simulationController.Stop();
        }

        private void PauseSimButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
