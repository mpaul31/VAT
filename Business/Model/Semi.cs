using System;

namespace VAT.Business.Model
{
    public class Semi : Vehicle
    {
        protected override bool CanTransferTo(Location destination)
        {
            return destination is DistributionCenter;
        }
    }
}
