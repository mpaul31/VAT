namespace VAT.Business.Model
{
    public class Branch : Location
    {
        protected override bool CanTransferTo(Vehicle vehicle)
        {
            return vehicle is Truck || vehicle is Van;
        }
    }
}