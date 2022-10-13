using System;
using System.Data;
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
    public class MetallsService:ServiceBase, IMetallService
    {
        private readonly IMetallRepository _metallRepository;
        private readonly IConnectionFactory _connectionFactory;
        private readonly ICacheModel _cacheModel;
        private readonly IMapper _mapper;

        public MetallsService(IMetallRepository metallRepository, 
                                IConnectionFactory connectionFactory, 
                                ICacheModel cacheModel, 
                                IMapper mapper)
        {
            _metallRepository = metallRepository;
            _connectionFactory = connectionFactory;
            _cacheModel = cacheModel;
            _mapper = mapper;
        }

        public async Task<int> AddItem(Metall metall)
        {
            var dto = _mapper.Map<MetallDTO>(metall);
            dto.RecordDate = DateTimeOffset.Now.ToUniversalTime();

            int id;
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    id = await _metallRepository.CreateAsync(dto, transaction);
                    transaction.Commit();
                }
                connection.Close();
            }
            return id;
        }

        public ResponseModel GetResponse(string code, DateTime? date)
        {
            if (!_cacheModel.Get(code, out MetallDTO metallDto))
            {
                metallDto = _metallRepository.SearchByCode(code, date);
                string cacheKey = $"{code}_AlphaCode_Metall_{date}";
                _cacheModel.Add(cacheKey, metallDto);
            }

            var r = _mapper.Map<ResponseModel>(metallDto);
            var response = new ResponseModel
            {
                Code = metallDto?.AlphaCode,
                Price = metallDto?.Price,
                Scale = 1
            };

            LogInformation(response);

            return r;
        }

        public bool CheckLastDate()
        {
            return _metallRepository.CheckLastDate();
        }

    }
}