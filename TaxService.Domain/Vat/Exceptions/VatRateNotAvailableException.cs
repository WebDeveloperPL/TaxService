using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.Domain.Vat.Exceptions
{
    public class VatRateNotAvailableException : Exception

    {
        public VatRateNotAvailableException(string message) : base(message)
        {
            
        }
    }
}
