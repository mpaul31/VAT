using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VAT.Business.Model
{
    public abstract class Location
    {
        private readonly IList<Vehicle> vehicles = new List<Vehicle>();

        public void Add(Vehicle vehicle)
        {
            if (this.vehicles.Contains(vehicle)) return;

            if (vehicle.Current == null)
            {
                vehicle.Current = this;
                this.vehicles.Add(vehicle);
            }
            else
            {
                vehicle.Transfer(this);
            }
        }

        public IReadOnlyCollection<Vehicle> Vehicles
        {
            get { return new ReadOnlyCollection<Vehicle>(this.vehicles); }
        }
    } 
}
