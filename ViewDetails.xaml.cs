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
using System.Windows.Shapes;

namespace TDD_ASS2
{
    /// <summary>
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        public ViewDetails()
        {
            InitializeComponent();
        }

        private Vehicle _vehicleInfo;


        public Vehicle VehicleInfo
        {
            get;
            set;
        }
        public int ID
        {
            get { return VehicleInfo.ID; }
            set { VehicleInfo.ID = value; }
        }

        public string Manufacturer
        {
            get { return VehicleInfo.Manufacturer; }
            set { VehicleInfo.Manufacturer = value; }
        }

        public int MakeYear
        {
            get { return VehicleInfo.MakeYear; }
            set { VehicleInfo.MakeYear = value; }
        }

        public int RegistrationNum
        {
            get { return VehicleInfo.RegistrationNum; }
            set { VehicleInfo.RegistrationNum = value; }
        }

        public int OdometerReading
        {
            get { return VehicleInfo.OdometerReading; }
            set { VehicleInfo.OdometerReading = value; }
        }

        public int TankCapacity
        {
            get { return VehicleInfo.TankCapacity; }
            set { VehicleInfo.TankCapacity = value; }
        }

        public string Model
        {
            get { return VehicleInfo.Model; }
            set { VehicleInfo.Model = value; }
        }

        public decimal LastServiceOdometerKM
        {
            get { return VehicleInfo.LastServiceOdometerKm; }
            set { VehicleInfo.LastServiceOdometerKm = value; }
        }

        public int ServiceCount
        {
            get { return VehicleInfo.ServiceCount; }
            set { VehicleInfo.ServiceCount = value; }
        }
        public double Journey
        {
            get { return VehicleInfo.Journey; }
            set { VehicleInfo.Journey = value; }
        }

        private void ViewDetailsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ManuTB.Text = VehicleInfo.Manufacturer;
            ModelTB.Text = VehicleInfo.Model;
            YearTB.Text = VehicleInfo.MakeYear.ToString();
            NumTB.Text = VehicleInfo.RegistrationNum.ToString();
            OdoTB.Text = VehicleInfo.OdometerReading.ToString();
            TankTB.Text = VehicleInfo.TankCapacity.ToString();
            ServiceTB.Text = VehicleInfo.LastServiceOdometerKm.ToString();
            ServiceBlock.Text = VehicleInfo.ServiceCount.ToString();
            JourneyTB.Text = VehicleInfo.Journey.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(YearTB.Text);
            int num = int.Parse(NumTB.Text);
            int odo = int.Parse(OdoTB.Text);
            int tank = int.Parse(TankTB.Text);
            decimal service = decimal.Parse(ServiceTB.Text);
            double jour = double.Parse(JourneyTB.Text);

            ID = 0;
            Manufacturer = ManuTB.Text;
            Model = ModelTB.Text;
            MakeYear = year;
            RegistrationNum = num;
            OdometerReading = odo;
            TankCapacity = tank;

            LastServiceOdometerKM = service;

            Journey = jour;

            this.Visibility = Visibility.Hidden;
        }


        private void PurchaseFuelButton_Click(object sender, RoutedEventArgs e)
        {
            double lit = double.Parse(PurTB.Text);
            double cost = double.Parse(FuelTB.Text);

            VehicleInfo.addFuel(lit, cost);
        }

        private void AddKiloToOdoButton_Click(object sender, RoutedEventArgs e)
        {
            OdoTB.Visibility = Visibility.Visible;
            AddKiloButton.Visibility = Visibility.Visible;
            AddKiloToOdoButton.Visibility = Visibility.Hidden;
        }

        private void AddKiloButton_Click(object sender, RoutedEventArgs e)
        {
            int odo = int.Parse(OdoTB.Text);
       
            OdometerReading = VehicleInfo.addKilometersOdo(odo);

            OdoTB.Text = OdometerReading.ToString();
        }

        private void RecordServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceTB.Visibility = Visibility.Visible;
            RecordButton.Visibility = Visibility.Hidden;
            RecordServiceButton.Visibility = Visibility.Visible;
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            decimal service = decimal.Parse(ServiceTB.Text);

            LastServiceOdometerKM = VehicleInfo.recordService(service);

            ServiceBlock.Text = VehicleInfo.ServiceCount.ToString();
            ServiceTB.Text = LastServiceOdometerKM.ToString();
        }

        private void RecordJourneyButton_Click(object sender, RoutedEventArgs e)
        {
            JourneyTB.Visibility = Visibility.Visible;
            RecordJourneyButton.Visibility = Visibility.Hidden;
            AddJourneyButton.Visibility = Visibility.Visible;
        }

        private void AddJourneyButton_Click(object sender, RoutedEventArgs e)
        {
            double journey = double.Parse(JourneyTB.Text);

            Journey = VehicleInfo.addKilometersJourney(journey);

            JourneyTB.Text = VehicleInfo.OdometerReading.ToString();
        }
    }
}

