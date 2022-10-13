using System;
using System.Threading;
using System.Threading.Tasks;
using CRB.BL.ReceivingDataServices.Interfaces;
using CRB.DA.AdjustedOptions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CRB.BL.ExternalServices
{
    public class CurrencyHostedService : IHostedService
    {
        private readonly ICurrencyReceiver _currencyReceiver;
        private readonly ReceivingConfiguration _receiveConfiguration;
        private Timer _timer;

        public CurrencyHostedService(ICurrencyReceiver currencyReceiver, 
                                    IOptions<ReceivingConfiguration> receivingConfig)
        {
            _currencyReceiver = currencyReceiver;
            _receiveConfiguration = receivingConfig.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CurrencyCallback, 
                            null, 
                                TimeSpan.FromSeconds(_receiveConfiguration.StartWorkFrom), 
                            TimeSpan.FromHours(_receiveConfiguration.IntervalOfReceive));
            
            return Task.CompletedTask;

        }

        private void CurrencyCallback(object state)
        {
            _ = _currencyReceiver.GetCurrency();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

      
    }
}