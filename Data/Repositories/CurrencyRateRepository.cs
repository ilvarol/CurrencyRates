using Core.Models.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CurrencyRateRepository : GenericRepository<CurrencyRate>, Core.Repositories.ICurrencyRateRepository
    {
        public CurrencyRateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
