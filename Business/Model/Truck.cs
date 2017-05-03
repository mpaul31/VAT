namespace VAT.Business.Model
{
    public class Truck : Vehicle
    {
        protected override bool CanTransferTo(Location destination)
        {
            return destination is Branch;
        }
    }
}
