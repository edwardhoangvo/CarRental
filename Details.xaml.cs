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
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details()
        {
            InitializeComponent();
            ServiceTB.Text = "0";
            ButtonStatus = true;
        }

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
        public bool ButtonStatus
        {
            get;
            set;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter all the Items \n Error:" + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            ButtonStatus = false;
        }
    }
}
