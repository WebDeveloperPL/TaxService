using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class VatGroup : BaseEntity
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public int VatRateId { get; set; }

        [ForeignKey("VatRateId")]
        public virtual VatRate VatRate { get; set; }
    }
}
