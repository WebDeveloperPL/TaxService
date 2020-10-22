using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.Domain.Vat
{
    using Core;
    using Data;
    using Database;

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
                }

                return vat.Rate;
            }
        }
    }
}
