using System;
using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using CENTROS.Core.DA.Interfaces;
using CRB.DA.CacheModel;
using CRB.DA.DTO;
using CRB.DA.Interfaces;
using CRB.DA.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CRB.BL.Services
{
    public class CurrencyService: ServiceBase, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IConnectionFactory _connectionFactory;
        private readonly ICacheModel _cacheModel;
        private readonly IMapper _mapper;

        public CurrencyService(ICurrencyRepository currencyRepository, 
                                IConnectionFactory connectionFactory,
                                ICacheModel cacheModel, 
                                IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _connectionFactory = connectionFactory;
            _cacheModel = cacheModel;
            _mapper = mapper;
        }

        public async Task<int> AddItem(Currency currency)
        {
            //var dto = new CurrencyDTO
            //{
            //    Name = currency.CurrencyData.Name,
            //    NumericCode = currency.CurrencyData.NumericCode,
            //    AlphaCode = currency.CurrencyData.AlphaCode,
            //    Price = currency.Price,
            //    Scale = currency.Scale,
            //    Date = currency.Date,
            //};

            var dto = _mapper.Map<CurrencyDTO>(currency); 
            dto.RecordDate = DateTime.Now.ToUniversalTime();

            int id;
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    id = await _currencyRepository.CreateAsync(dto, transaction);
                    transaction.Commit();
                }
                connection.Close();
            }
            return id;
        }

        public ResponseModel GetResponseByAlphaCode(string code, DateTime? date)
        {
            if (!_cacheModel.Get(code, out CurrencyDTO currencyDto))
            {
                currencyDto = _currencyRepository.SearchByAlphaCode(code, date);
                string cacheKey = $"{code}_AlphaCode_Currency_{date}";
                _cacheModel.Add(cacheKey, currencyDto);
            }

            var response = new ResponseModel
            {
                Code = currencyDto?.AlphaCode,
                Price = currencyDto?.Price,
                Scale = currencyDto?.Scale
            };

            LogInformation(response);

            return response;
        }

        public ResponseModel GetResponseByNumericCode(string code, DateTime? date)
        {
            if (!_cacheModel.Get(code, out CurrencyDTO currencyDto))
            {
                currencyDto = _currencyRepository.SearchByNumericCode(code, date);
                string cacheKey = $"{code}_NumericCode_Currency_{date}";
                _cacheModel.Add(cacheKey, currencyDto);
            }

            var response = new ResponseModel
            {
                Code = currencyDto?.NumericCode,
                Price = currencyDto?.Price,
                Scale = currencyDto?.Scale
            };

            LogInformation(response);

            return response;
        }

        public bool CheckLastDate()
        {
            return _currencyRepository.CheckLastDate();
        }
    }
}