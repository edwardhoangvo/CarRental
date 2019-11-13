using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_ASS2
{
    public class Vehicle
    {
        private string manufacturer;
        private string model;
        private int makeYear;
        // TODO add Registration Number
        private int registrationNum;
        // TODO add variable for OdometerReading (in KM),
        private int odometerReading;
        // TODO add variable for TankCapacity (in litres)
        private int tankCapacity;

        private FuelPurchase fuelPurchase;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public int MakeYear
        {
            get { return makeYear; }
            set { makeYear = value; }
        }

        public int RegistrationNum
        {
            get { return registrationNum; }
            set { registrationNum = value; }
        }

        public int OdometerReading
        {
            get { return odometerReading; }
            set { odometerReading = value; }
        }

        public int TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
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
        public int addKilometers(int distanceTraveled)
        {
            odometerReading += distanceTraveled;
            return odometerReading;
        }

        // adds fuel to the car
        public void addFuel(double litres, double price)
        {
            fuelPurchase.purchaseFuel(litres, price);
        }
    }
}
