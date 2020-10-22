namespace TaxService.Domain.Vat
{
    using System.Linq;
    using Core;
    using Data;
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IVatRateRepository
    {
        VatRate GetVateRate(TaxDbContext db, string category);
        VatRate GetDefault(TaxDbContext db);
    }

    [RegisterScoped]
    public class VatRateRepository : IVatRateRepository
    {
        public VatRate GetVateRate(TaxDbContext db, string category)
        {
            var group = db.VatGroups.Include(x => x.VatRate).FirstOrDefault(x => x.Key == category);

            if (group != null)
            {
                return group.VatRate;
            }

            return null;
        }

        public VatRate GetDefault(TaxDbContext db)
        {
            var group = db.VatRates.FirstOrDefault(x=>x.IsDefault == true);
            return group;
        }
    }
}