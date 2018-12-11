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
using System.Threading;

namespace Dinner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Model.IRender<DiningRoom>
    {
        private SimulationController simulationController;
        private DataTable Tablesdata;
        private DataTable Staffdata;
        public MainWindow()
        {
            //DinnerConnection.Instance.Start();

            InitializeComponent();
            
            simulationController = new SimulationController(Render, Thread.CurrentThread);
            Tablesdata = new DataTable();
            Tablesdata.Columns.Add("Table", typeof(string));
            Tablesdata.Columns.Add("Numbers Of Client", typeof(int));
            Tablesdata.Columns.Add("Status", typeof(string));
            Tablesdata.Columns.Add("Number Chairs", typeof(int));

            Staffdata = new DataTable();
            Staffdata.Columns.Add("Staff", typeof(string));
            Staffdata.Columns.Add("Status", typeof(string));


            //data.Rows.Add("Table 1", 10, Model.TableStatus.CHOOSEN.ToString());
            DataGridDinner.ItemsSource = Tablesdata.AsDataView();
            StaffStatus.ItemsSource = Staffdata.AsDataView();


        }

        public void Render(DiningRoom dining)
        {

            this.NumberClient.Content = $"Number of client : {dining.Clients.Length}";
            this.TickCount.Content = $"Tick : {simulationController.Ticks}";

            this.NumberTable.Content = $"Number of Table : {dining.Tables.Length}";

            this.NumberClientInLoby.Content = $"Number of Client in lobby : {dining.Lobby.Count}";
            Tablesdata.Clear();
            for(int i = 0; i < dining.Tables.Length; i++)
            {
                Tablesdata.Rows.Add($"Table {i}", dining.Tables[i].Items().Count, dining.Tables[i].TableOrderStatus.ToString(), 
                    dining.Tables[i].NumberSlots);
            }

            Staffdata.Clear();
            dining.HeadWaiters.ToList().ForEach(HeadWaiter =>
            {
                Staffdata.Rows.Add("HeadWeater", HeadWaiter.TaskProcessor.CurrentTask.Name);
            });

            dining.Waiters.ToList().ForEach(waiter =>
            {
                Staffdata.Rows.Add("Waiter", waiter.TaskProcessor.CurrentTask.Name);
            });

            Staffdata.Rows.Add("ClerkWaiter", dining.ClerkWaiter.TaskProcessor.CurrentTask.Name);



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
            simulationController.Stop();
        }

        private void SpeedSim_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (simulationController == null) return;
            if (e.NewValue > e.OldValue)
            {
                simulationController.SpeedUp();
            }else if(e.NewValue < e.OldValue)
            {
                simulationController.SlowDown();
            }
            
        }
    }
}
