﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TDD_ASS2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //XXXXXX

        ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
        //ObservableCollection<Service> services = new ObservableCollection<Service>();
        int vehicleCount = 0;


        public Vehicle xVehicle;
        public Vehicle updatedVehicle;
        //public Service xService;

        //Service[] serviceList = new Service[30]; 

        public MainWindow()
        {
            InitializeComponent();

            xVehicle = new Vehicle();
            //xService = new Service();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Details enterDetails = new Details();

            xVehicle.Manufacturer = "";
            xVehicle.Model = "";
            xVehicle.MakeYear = 0;
            xVehicle.RegistrationNum = 0;
            xVehicle.OdometerReading = 0;
            xVehicle.TankCapacity = 0;
            xVehicle.LastServiceOdometerKm = 0;
            

            enterDetails.VehicleInfo = xVehicle;

            //enterDetails.ServiceInfo = xService;

            enterDetails.Owner = this;

            enterDetails.WindowStartupLocation = WindowStartupLocation.Manual;

            enterDetails.ShowDialog();

            this.xVehicle = enterDetails.VehicleInfo;

            enterDetails.Close();

            vehicles.Add(new Vehicle() {
                ID = vehicleCount,
                Manufacturer = xVehicle.Manufacturer,
                Model = xVehicle.Model,
                MakeYear = xVehicle.MakeYear,
                RegistrationNum = xVehicle.RegistrationNum,
                OdometerReading = xVehicle.OdometerReading,
                TankCapacity = xVehicle.TankCapacity,
                LastServiceOdometerKm = xVehicle.LastServiceOdometerKm,
                ServiceCount = xVehicle.ServiceCount,
                Journey = xVehicle.Journey
                });


            vehicleCount++;

            VehicleList.ItemsSource = vehicles;
         
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void EdditButton_Click(object sender, RoutedEventArgs e)
        {
            ViewDetails details = new ViewDetails();

            int selectedItemIndex = VehicleList.SelectedIndex;


            details.VehicleInfo = this.vehicles[selectedItemIndex];



            details.Owner = this;

            details.WindowStartupLocation = WindowStartupLocation.Manual;

            details.Left = details.Owner.Left + details.Owner.Width - details.Width;

            details.Top = details.Owner.Top;

            details.ShowDialog();

            this.updatedVehicle = details.VehicleInfo;

            for (int i = 0; i < vehicleCount; i++)
            {
                if (vehicles[i].ID == selectedItemIndex)
                {
                    vehicles[i] = this.updatedVehicle;

                }
            }

            //foreach (Vehicle eachItem in VehicleList.SelectedItems)
            //{
            //    VehicleList.Items.Remove(eachItem);
            //}



            //vehicles.Add(new Vehicle()
            //{
            //    //ID = vehicleCount,
            //    Manufacturer = updatedVehicle.Manufacturer,
            //    Model = updatedVehicle.Model,
            //    MakeYear = updatedVehicle.MakeYear,
            //    RegistrationNum = updatedVehicle.RegistrationNum,
            //    OdometerReading = updatedVehicle.OdometerReading,
            //    TankCapacity = updatedVehicle.TankCapacity,
            //    LastServiceOdometerKm = updatedVehicle.LastServiceOdometerKm,
            //    ServiceCount = updatedVehicle.ServiceCount,
            //    Journey = updatedVehicle.Journey
            //});

            VehicleList.ItemsSource = vehicles;


        }
    }
}
