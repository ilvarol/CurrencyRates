using Core.Common;
using Core.Interfaces;
using Core.Models.Business;
using Core.Models.Entities;
using Core.Repositories;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Service.HostedServices
{
    public class TransferDailyCurrencyRates : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private Timer _timer = null!;

        private readonly ILogger<TransferDailyCurrencyRates> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TransferDailyCurrencyRates(
            ILogger<TransferDailyCurrencyRates> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            SaveDailyCurrencyRatesFromTCMB();

            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


        private void SaveDailyCurrencyRatesFromTCMB()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _currencyRateRepository = scope.ServiceProvider.GetService<Core.Repositories.ICurrencyRateRepository>();

                var _unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();

                var list = new TCMB().FetchCurrencyRatesFromTCMB();

                list = list.Where(x => Enum.GetNames(typeof(CurrencyRateType)).Contains(x.CurrencyCode)).ToList();

                foreach (var item in list)
                {
                    var test = new CurrencyRate();

                    test.Date = DateTime.Now;
                    test.Type = (CurrencyRateType)Enum.Parse(typeof(CurrencyRateType), item.CurrencyCode);
                    test.Rate = double.Parse(item.ForexSelling);

                    var yesterdayRate = _currencyRateRepository
                        .Where(x => x.Date.Date == DateTime.Now.AddDays(-1).Date && x.Type == test.Type)
                        .FirstOrDefault();

                    test.Changes = yesterdayRate != null ? ((test.Rate - yesterdayRate.Rate) / Math.Abs(yesterdayRate.Rate)) * 100 : 0;

                    _currencyRateRepository.AddAsync(test);
                }

                _unitOfWork.Commit();
            }
        }
    }
}
