namespace TaxService.Domain.Vat
{
    using System;
    using Core;
    using Database;
    using Exceptions;

    public interface IVatRateProvider
    {
        int GetVatRate(string groupName);
    }

    [RegisterScoped]
    public class VatRateProvider : IVatRateProvider
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IVatRateRepository _vatRateRepository;

        public VatRateProvider(IDbContextFactory dbContextFactory, IVatRateRepository vatRateRepository)
        {
            _dbContextFactory = dbContextFactory;
            _vatRateRepository = vatRateRepository;
        }

        public int GetVatRate(string groupName)
        {
            using (var db = _dbContextFactory.Create())
            {
                var vat = _vatRateRepository.GetVateRate(db, groupName);
                if (vat == null)
                {
                    vat = _vatRateRepository.GetDefault(db);
                    if (vat == null)
                    {
                        throw new VatRateNotAvailableException($"Vat rate not available for {groupName}");
                    }
                }
                
                return vat.Rate;
            }
        }
    }
}