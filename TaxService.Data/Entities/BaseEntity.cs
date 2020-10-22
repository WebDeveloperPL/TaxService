using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
