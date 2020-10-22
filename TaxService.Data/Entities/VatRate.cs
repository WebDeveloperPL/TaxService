using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.Data.Entities
{
    public class VatRate : BaseEntity
    {
        public int Rate { get; set; }
        public bool IsDefault { get; set; }
        
    }
}
