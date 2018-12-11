﻿using System;
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
        private DataTable data;
        public MainWindow()
        {
            //DinnerConnection.Instance.Start();

            InitializeComponent();
            
            simulationController = new SimulationController(Render, Thread.CurrentThread);
            data = new DataTable();
            data.Columns.Add("Table", typeof(string));
            data.Columns.Add("Numbers Of Client", typeof(int));
            data.Columns.Add("Status", typeof(string));

            //data.Rows.Add("Table 1", 10, Model.TableStatus.CHOOSEN.ToString());
            DataGridDinner.ItemsSource = data.AsDataView();


        }

        public void Render(DiningRoom dining)
        {

            this.NumberClient.Content = $"Number of client : {dining.Clients.Length}";
            this.TickCount.Content = $"Tick : {simulationController.Ticks}";

            this.NumberTable.Content = $"Number of Table : {dining.Tables.Length}";

            this.NumberClientInLoby.Content = $"Number of Client in lobby : {dining.Lobby.Count}";
            data.Clear();
            for(int i = 0; i < dining.Tables.Length; i++)
            {
                data.Rows.Add($"Table {i}", dining.Tables[i].Items().Count, dining.Tables[i].TableOrderStatus.ToString());
            }


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
