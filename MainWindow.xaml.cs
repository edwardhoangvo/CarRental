using System;
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
        ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
        int vehicleCount = 0;
        public Vehicle xVehicle;
        public Vehicle updatedVehicle;

        public MainWindow()
        {
            InitializeComponent();

            xVehicle = new Vehicle();
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

            enterDetails.Owner = this;

            enterDetails.WindowStartupLocation = WindowStartupLocation.Manual;

            enterDetails.ShowDialog();

            this.xVehicle = enterDetails.VehicleInfo;

            enterDetails.Close();
          
            if (enterDetails.ButtonStatus == true)
            {
                vehicles.Add(new Vehicle()
                {
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
            }

            VehicleList.ItemsSource = vehicles;
        }

        public void RemoveItem(ObservableCollection<Vehicle> collection, Vehicle instance)
        {
            collection.Remove(collection.Where(i => i.ID == instance.ID).Single());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedItemIndex = VehicleList.SelectedIndex;

                RemoveItem(vehicles, vehicles[selectedItemIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select a vehicle to Delete\n Error:" + ex.Message);
            }
        }

        private void EdditButton_Click(object sender, RoutedEventArgs e)
        {
            try
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

                VehicleList.ItemsSource = vehicles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select a vehicle to Edit\n Error:" + ex.Message);
            }
        }
    }
}
