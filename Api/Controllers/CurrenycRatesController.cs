using Core.Interfaces;
using Core.Models.Business;
using Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrenycRatesController : BaseController
    {
        private readonly ICurrencyRateService _currencyRateService;

        public CurrenycRatesController(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpGet("GetCurrentCurrencyRates")]
        public IActionResult GetCurrentCurrencyRates()
        {
            return ActionResultInstance(_currencyRateService.GetCurrentCurrencyRates());
        }

        [HttpGet("GetCurrencyRates")]
        public IActionResult GetCurrencyRates(CurrencyRateType currencyRateType)
        {
            return ActionResultInstance(_currencyRateService.GetCurrencyRates(currencyRateType));
        }
    }
}
