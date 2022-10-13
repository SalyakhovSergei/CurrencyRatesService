using System;
using System.Threading;
using System.Threading.Tasks;
using CRB.BL.ReceivingDataServices.Interfaces;
using CRB.DA.AdjustedOptions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CRB.BL.ExternalServices
{
    public class MetallsHostedServices: IHostedService
    {
        private readonly IMetallReciever _metallReciever;
        private ReceivingConfiguration _receiveConfiguration;
        private Timer _timer;

        public MetallsHostedServices(IMetallReciever metallReciever, 
                                    IOptions<ReceivingConfiguration> receivingConfig)
        {
            _metallReciever = metallReciever;
            _receiveConfiguration = receivingConfig.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(MetallCallback,
                null,
                TimeSpan.FromSeconds(_receiveConfiguration.StartWorkFrom),
                TimeSpan.FromHours(_receiveConfiguration.IntervalOfReceive));
            return Task.CompletedTask;
        }

        private void MetallCallback(object state)
        {
            _ = _metallReciever.GetMetalls();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}