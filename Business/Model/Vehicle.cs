using System;
using System.Linq;

namespace VAT.Business.Model
{
    public abstract class Vehicle
    {
        private int year;
        private string vin;

        public string Make
        {
            get;
            private set;
        }

        public string Model
        {
            get;
            private set;
        }

        public int Year
        {
            get { return this.year; }
            set
            {
                if (value.ToString().Length != 4) throw new ArgumentException("Year must be four numeric characters.");
                this.year = value;
            }
        }

        public string VIN
        {
            get { return this.vin; }
            set
            {
                if (value == null) throw new ArgumentNullException();

                // the following validation was choosen over regex for readability purposes. this could easily be refactored to make use of regex.
                //
                bool valid = value.Length == 24
                    && value.Count(char.IsLetter) >= 8
                    && value.Reverse().Take(5).Count(char.IsNumber) == 5;

                if (!valid) throw new ArgumentException("VIN must be 24 alphanumeric characters with a minimum of 8 alphas, ending with 5 numeric.");

                this.vin = value;
            }
        }

        public Location Current
        {
            get;
            set;
        }

        public VehicleStatus Status
        {
            get;
            private set;
        }

        public void Transfer(Location destination)
        {
            if (this.Current == destination) return;

            if (this.Status != VehicleStatus.StandBy) throw new VehicleTransferException("Vehicle must be in stand-by in order to transfer.");

            if (this.CanTransferTo(destination) == false) throw new VehicleTransferException("Unable to transfer vehicle at this time.");

            this.Current = destination;
        }

        protected abstract bool CanTransferTo(Location destination);
    }
}
