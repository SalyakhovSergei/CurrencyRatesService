using System;
using System.Threading.Tasks;
using ClassLibrary1;
using CRB.BL.ReceivingDataServices.Interfaces;
using CRB.BL.Services;
using CRB.DA.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace centros_ref_book.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatesCBController: ControllerBase 
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMetallService _metallService;
        private ResponseModel _response;
        private readonly ICurrencyReceiver _currencyReceiver;
        private readonly IMetallReciever _metallReciever;

        public RatesCBController(ICurrencyService currencyService, 
                                    IMetallService metallService, 
                                    ICurrencyReceiver currencyReceiver, 
                                    IMetallReciever metallReciever)
        {
            _currencyService = currencyService;
            _metallService = metallService;
            _currencyReceiver = currencyReceiver;
            _metallReciever = metallReciever;
        }
        
        [HttpGet]
        [Route("SearchData/{code}/{date?}")]
        public async Task<ActionResult<ResponseModel>> SearchData(string code, DateTime? date)
        {
            int loopCount = 0;

            date ??= DateTime.Today;

            bool isNumericCode = int.TryParse(code, out int numericCode);

            while (!CheckSearchLoop(_response, loopCount))
            {
                try
                {
                    //пока закомментировал потому что Банщиков сказал что они будут искать только по цифровому коду
                    //Log.Information($"Get currency by AlphaCode request for {code} on date: {date}");
                    //_response = _currencyService.GetResponseByAlphaCode(code, date);
                    
                    if (isNumericCode)
                    {
                        Log.Information($"Get currency request by NumericCode for {code} on date: {date}");
                        _response = _currencyService.GetResponseByNumericCode(code, date);
                    }

                    if ((_response is null || _response.Code is null || _response.Price is null) && !isNumericCode)
                    {
                        Log.Information($"Get metal request for {code} on date: {date}");
                        _response = _metallService.GetResponse(code, date);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
                date = date.Value.AddDays(-1);
                loopCount++;
            }

            

            Log.Information("Query finished");

            if (_response.Price is null || _response.Code is null)
            {
                return Ok(StatusCode(204));
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("RefreshData")]
        public async Task<ActionResult> RefreshData()
        {
            try
            {
                var currencyResult = await _currencyReceiver.GetCurrency();
                var metalResult = await _metallReciever.GetMetalls();

                return Ok($"{currencyResult}; {metalResult}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return Ok(e.Message);
            }
        }


        private bool CheckSearchLoop(ResponseModel response, int count)
        {
            return (response?.Code != null || response?.Price != null || count == 30);
        }
    }
}