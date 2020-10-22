namespace TaxService.Data
{
    using System;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    public class TaxDbContext : DbContext
    {
        public DateTime? Created { get; set; }

        public TaxDbContext(DbContextOptions<TaxDbContext> options)
            : base(options)
        { }


        public DbSet<VatRate> VatRates { get; set; }
        public DbSet<VatGroup> VatGroups { get; set; }
    }
}