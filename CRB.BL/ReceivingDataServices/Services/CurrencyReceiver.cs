using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClassLibrary1;
using CRB.BL.ReceivingDataServices.Interfaces;
using CRB.BL.Services;
using CRB.DA.Models;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;

namespace CRB.BL.ReceivingDataServices.Services
{
    public class CurrencyReceiver: ICurrencyReceiver
    {
        private readonly ICurrencyService _currencyService;
        private readonly IAxiomaOMNIcurrencyratesRESTAPIClient _axiomaOmnIcurrencyrates;
        private readonly IMapper _mapper;

        public CurrencyReceiver(ICurrencyService currencyService, 
                                    IAxiomaOMNIcurrencyratesRESTAPIClient axiomaOmnIcurrencyrates, 
                                    IMapper mapper)
        {
            _currencyService = currencyService;
            _axiomaOmnIcurrencyrates = axiomaOmnIcurrencyrates;
            _mapper = mapper;
        }

        public async Task<string> GetCurrency()
        {
            string result = "Currency refreshed";
      
            try
            {
                RatesOnDateResponse response = _axiomaOmnIcurrencyrates.DailyFxratesAsync(DateTimeOffset.Now.Date).Result;
                
                var currencyRate = _mapper.Map<CurrencyRate>(response);
                var rates = currencyRate.Rates;

                foreach (var rate in rates)
                {
                    rate.Date = currencyRate.Date;
                    int id = await _currencyService.AddItem(rate);
                }
                Log.Information($"Currency uploaded on date {currencyRate.Date}");
            }
            catch (Exception e)
            {
                result = e.Message;
                Log.Error(e.Message);
            }

            return result;
        }
    }
}