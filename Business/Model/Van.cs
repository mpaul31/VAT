namespace VAT.Business.Model
{
    public class Van : Vehicle
    {
        protected override bool CanTransferTo(Location destination)
        {
            return destination is Branch;
        }
    }
}
