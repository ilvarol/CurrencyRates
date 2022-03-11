using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Entities
{
    public class CurrencyRate
    {
        public int Id { get; set; }

        public CurrencyRateType Type { get; set; }

        public DateTime Date { get; set; }

        public double Rate { get; set; }

        public double Changes { get; set; }
    }

    public enum CurrencyRateType
    {
        USD, EUZ, GBP, CHF, KWD, SAR, RUB, TRY
    }
}
