using Core.Models.Entities;

namespace Core.Models.Dto
{
    public class CurrencyRatesDto
    {
        public CurrencyRateType Type { get; set; }

        public DateTime Date { get; set; }

        public double Rate { get; set; }

        public double Changes { get; set; }
    }
}