using System;

namespace VAT.Business.Model
{
    public class VehicleTransferException : ApplicationException
    {
        public VehicleTransferException(string message) : base(message) { }
    }
}
