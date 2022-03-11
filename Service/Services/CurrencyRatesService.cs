using Core.Interfaces;
using Core.Models.Business;
using Core.Models.Dto;
using Core.Models.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Dto;
using System.Xml;

namespace Service.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public CurrencyRateService(ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
        }

        public Response<IList<CurrencyRatesDto>> GetCurrencyRates(CurrencyRateType currencyRateType)
        {
            var currencyRates = _currencyRateRepository
                .Where(x => x.Type == currencyRateType)
                .OrderBy(x => x.Date)
                .ToList();

            var currencyRatesDtos = ObjectMapper.Mapper.Map<IList<CurrencyRatesDto>>(currencyRates);

            return Response<IList<CurrencyRatesDto>>.Success(currencyRatesDtos, 200);
        }

        public Response<IList<CurrencyRatesDto>> GetCurrentCurrencyRates()
        {
            var currencyRates = _currencyRateRepository
                .Where(x => x.Date.Date == DateTime.Today.Date)
                .OrderBy(o => o.Type)
                .OrderByDescending(o => o.Rate)
                .ToList();

            var currencyRatesDtos = ObjectMapper.Mapper.Map<IList<CurrencyRatesDto>>(currencyRates);

            return Response<IList<CurrencyRatesDto>>.Success(currencyRatesDtos, 200);
        }
    }
}
