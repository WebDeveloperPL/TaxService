﻿namespace TaxService.Domain.Calcaulator
{
    using System.Collections.Generic;
    using Core;
    using Model.Api.Calcualte;
    using Vat;

    public interface ICalculator
    {
        List<CalculatedItemWithVatDto> CalculateVat(List<CalculatePostModel> model);
    }

    [RegisterScoped]
    public class Calculator : ICalculator
    {
        private readonly IVatRateProvider _vatRateProvider;
        private readonly ICalculatedVatItemDtoFactory _calculatedVatItemDtoFactory;

        public Calculator(IVatRateProvider vatRateProvider, ICalculatedVatItemDtoFactory calculatedVatItemDtoFactory)
        {
            _vatRateProvider = vatRateProvider;
            _calculatedVatItemDtoFactory = calculatedVatItemDtoFactory;
        }

        public List<CalculatedItemWithVatDto> CalculateVat(List<CalculatePostModel> model)
        {
            var output = new List<CalculatedItemWithVatDto>();
            foreach (var item in model)
            {
                var vat = _vatRateProvider.GetVatRate(item.Key);
                output.Add(_calculatedVatItemDtoFactory.Create(item, vat));
            }

            return output;

        }
    }
}