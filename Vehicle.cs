using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_ASS2
{
    public class Vehicle : INotifyPropertyChanged
    {
        public static int SERVICE_KILOMETER_LIMIT = 10000;


        private int id;
        private string manufacturer;
        private string model;
        private int makeYear;
        // TODO add Registration Number
        private int registrationNum;
        // TODO add variable for OdometerReading (in KM),
        private int odometerReading;
        // TODO add variable for TankCapacity (in litres)
        private int tankCapacity;
        private double journey;
        private decimal lastServiceOdometerKm;
        private int serviceCount;

        private FuelPurchase fuelPurchase;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public Vehicle()
        {
            ID = 0;
            Manufacturer = "";
            Model = "";
            MakeYear = 0;
            RegistrationNum = 0;
            OdometerReading = 0;
            TankCapacity = 0;
            LastServiceOdometerKm = 0;
            ServiceCount = 0;
            journey = 0;
        }


        public int ID
        {
            get { return id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("ID");
                }
            }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (this.manufacturer != value)
                {
                    this.manufacturer = value;
                    this.NotifyPropertyChanged("Manufacturer");
                }
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (this.model != value)
                {
                    this.model = value;
                    this.NotifyPropertyChanged("Model");
                }
            }
        }

        public int MakeYear
        {
            get { return makeYear; }
            set
            {
                if (this.makeYear != value)
                {
                    this.makeYear = value;
                    this.NotifyPropertyChanged("MakeYear");
                }
            }
        }

        public int RegistrationNum
        {
            get { return registrationNum; }
            set
            {
                if (this.registrationNum != value)
                {
                    this.registrationNum = value;
                    this.NotifyPropertyChanged("RegistrationNum");
                }
            }
        }

        public int OdometerReading
        {
            get { return odometerReading; }
            set
            {
                if (this.odometerReading != value)
                {
                    this.odometerReading = value;
                    this.NotifyPropertyChanged("OdometerReading");
                }
            }
        }

        public int TankCapacity
        {
            get { return tankCapacity; }
            set
            {
                if (this.tankCapacity != value)
                {
                    this.tankCapacity = value;
                    this.NotifyPropertyChanged("TankCapacity");
                }
            }
        }

        public decimal LastServiceOdometerKm
        {
            get { return lastServiceOdometerKm; }
            set
            {
                if (this.lastServiceOdometerKm != value)
                {
                    this.lastServiceOdometerKm = value;
                    this.NotifyPropertyChanged("LastServiceOdometerKm");
                }
            }
        }

        public int ServiceCount
        {
            get { return serviceCount; }
            set
            {
                if (this.serviceCount != value)
                {
                    this.serviceCount = value;
                    this.NotifyPropertyChanged("ServiceCount");
                }
            }
        }

        public double Journey
        {
            get { return journey; }
            set
            {
                if (this.journey != value)
                {
                    this.journey = value;
                    this.NotifyPropertyChanged("Journey");
                }
            }
        }

        /**
         * Class constructor specifying name of make (manufacturer), model and year
         * of make.
         * @param manufacturer
         * @param model
         * @param makeYear
         */

        //public Vehicle(String manufacturer, String model, int makeYear, int registrationNum,int odometerReading, int tankCapacity)
        //{
        //    this.manufacturer = manufacturer;
        //    this.model = model;
        //    this.makeYear = makeYear;
        //    this.registrationNum = registrationNum;
        //    this.odometerReading = odometerReading;
        //    this.tankCapacity = tankCapacity;

        //    fuelPurchase = new FuelPurchase();
        //}


        // TODO Add missing getter and setter methods

        /**
         * Prints details for {@link Vehicle}
         */
        public void printDetails()
        {
            Console.WriteLine("Vehicle: " + makeYear + " " + manufacturer + " " + model + " " + registrationNum + " " +
              +odometerReading + " " + tankCapacity);
            // TODO Display additional information about this vehicle
        }


        // TODO Create an addKilometers method which takes a parameter for distance travelled 
        // and adds it to the odometer reading. 
        public int addKilometersOdo(int distanceTraveled)
        {
            OdometerReading += distanceTraveled;
            return OdometerReading;
        }

        // adds fuel to the car
        public void addFuel(double litres, double price)
        {
            fuelPurchase.purchaseFuel(litres, price);
        }

        public decimal recordService(decimal distance)
        {
            this.serviceCount++;
            return lastServiceOdometerKm = distance;
        }

        // return how many services the car has had
        public int getServiceCount()
        {
            return this.serviceCount;
        }

        /**
         * Calculates the total services by dividing kilometers by
         * {@link #SERVICE_KILOMETER_LIMIT} and floors the value. 
         * 
         * @return the number of services needed per SERVICE_KILOMETER_LIMIT
         */
        public int getTotalScheduledServices()
        {
            return (int)Math.Floor(lastServiceOdometerKm / SERVICE_KILOMETER_LIMIT);
        }

        /** 
         * Appends the distance parameter to {@link #kilometers}
         * @param kilometers the distance traveled 
         */
        public double addKilometersJourney(double journey)
        {
            this.journey += journey;
            return journey;
        }

        /**
         * Getter method for total Kilometers traveled in this journey.
         * @return {@link #kilometers}
         */
        public double getKilometers()
        {
            return journey;
        }
    }
}
