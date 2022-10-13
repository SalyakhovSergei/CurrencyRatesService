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

namespace CRB.BL.ReceivingDataServices.Services
{
    public class MetallReceiver: IMetallReciever
    {
        private IMetallService _metallService;
        private IAxiomaOMNIcurrencyratesRESTAPIClient _axiomaClient;
        private readonly IMapper _mapper;

        public MetallReceiver(IMetallService metallService, 
                                IAxiomaOMNIcurrencyratesRESTAPIClient axiomaClient, 
                                IMapper mapper)
        {
            _metallService = metallService;
            _axiomaClient = axiomaClient;
            _mapper = mapper;
        }

        public async Task<string> GetMetalls()
        {
            string result = "Metals refreshed";
            
            try
            {
               MetalsOnDateResponse response = _axiomaClient.MetalsAsync(DateTimeOffset.Now.Date).Result;
                   
               var metallRate = _mapper.Map<MetallRate>(response);
               var rates = metallRate?.Rates;

               foreach (var rate in rates)
               {
                   rate.Date = metallRate.Date;
                   int id = await _metallService.AddItem(rate);
               }
               Log.Information($"Metalls uploaded on date {metallRate.Date}");
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Log.Error(ex.Message);
            }

            return result;
        }
    }
}