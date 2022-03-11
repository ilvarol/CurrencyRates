using Core.Models.Business;
using Core.Models.Dto;
using Core.Models.Entities;
using Shared.Models.Dto;

namespace Core.Interfaces
{
    public interface ICurrencyRateService
    {
        Response<IList<CurrencyRatesDto>> GetCurrencyRates(CurrencyRateType currencyRateType);

        Response<IList<CurrencyRatesDto>> GetCurrentCurrencyRates();
    }
}