using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VAT.Business.Model
{
    public class DistributionCenter : Location
    {
        private readonly IList<Branch> branches;

        public DistributionCenter()
        {
            this.branches = new List<Branch>();
        }

        protected override bool CanTransferTo(Vehicle vehicle)
        {
            return vehicle is Semi;
        }

        public IReadOnlyCollection<Branch> Branches
        {
            get { return new ReadOnlyCollection<Branch>(this.branches); }
        }
    }
}
