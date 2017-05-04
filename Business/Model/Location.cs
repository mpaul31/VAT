using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace VAT.Business.Model
{
    public abstract class Location
    {
        private readonly IList<Vehicle> vehicles = new List<Vehicle>();

        public virtual void Add(Vehicle vehicle)
        {
            if (this.Vehicles.Contains(vehicle)) return;

            if (vehicle.Current == null)
            {
                vehicle.Current = this;

                this.vehicles.Add(vehicle);                
            }
            else
            {
                this.ReceiveTransfer(vehicle);
            }
        }

        public virtual void ReceiveTransfer(Vehicle vehicle)
        {
            if (this.Vehicles.Contains(vehicle)) return;

            if (vehicle.Current == null) throw new VehicleTransferException("Vehicle must have a location set before transfer can take place.");

            if (CanTransferTo(vehicle) == false) throw new VehicleTransferException("....");

            vehicle.Current = this;

            this.vehicles.Add(vehicle);
        }

        public IReadOnlyCollection<Vehicle> Vehicles
        {
            get { return new ReadOnlyCollection<Vehicle>(this.vehicles); }
        }

        protected abstract bool CanTransferTo(Vehicle vehicle);
    } 
}
