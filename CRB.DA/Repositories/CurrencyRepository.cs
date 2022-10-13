using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using CENTROS.Core.DA.Interfaces;
using CENTROS.Core.DA.PgSql;
using CRB.DA.DTO;
using CRB.DA.Interfaces;
using CRB.DA.Responses;
using Dapper;
using Dapper.Contrib.Extensions;
using Serilog;

namespace CRB.DA.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IConnectionFactory _connFactory;

        public CurrencyRepository(IConnectionFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public async Task<int> CreateAsync(CurrencyDTO item, IDbTransaction transaction = null)
        {
            try
            {
                using var connection = _connFactory.GetConnection(transaction);
                if (CheckItemInDb(item)?.Date != item.Date)
                {
                    var id = await connection.InsertSingleAsync(item, r => r.Id, transaction, tableName: "crb.currency");
                    return id;
                }
                if (CheckItemInDb(item)?.Date == item.Date && (CheckItemInDb(item)?.Price != item.Price || CheckItemInDb(item)?.Scale != item.Scale))
                {
                    var id = await connection.InsertSingleAsync(item, r => r.Id, transaction, tableName: "crb.currency");
                    return id;
                }
                
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            
            return 0;
        }

        //метод для обновления сущности в БД, оказался не нужен, но пока оставил
        public Task<int> UpdateAsync(CurrencyDTO item, IDbTransaction transaction = null)
        {
            try
            {
                using var conn = _connFactory.GetConnection(transaction);

                var sql = $@"UPDATE crb.currency SET ""Price""={item.Price.ToString().Replace(',', '.')}, ""Scale""={item.Scale} 
                                        WHERE ""NumericCode""='{item.NumericCode}' 
                                        AND ""AlphaCode""='{item.AlphaCode}'
                                        AND ""Date""='{item.Date:dd/MM/yyyy}'";
                
                var result = conn.QuerySingleOrDefault(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            
            return Task.FromResult(0);
        }

        public CurrencyDTO SearchByAlphaCode(string code, DateTimeOffset? date, IDbTransaction transaction = null)
        {
            using var conn = _connFactory.GetConnection(transaction);
            var sql = $@"SELECT * FROM crb.currency WHERE ""AlphaCode""=@code and ""Date""='{date.Value:dd/MM/yyyy}' LIMIT 1";
            var result = conn.QuerySingleOrDefault<CurrencyDTO>(sql, new {code}, transaction);
            return result;

        }

        public CurrencyDTO SearchByNumericCode(string code, DateTimeOffset? date, IDbTransaction transaction = null)
        {
            using var conn = _connFactory.GetConnection(transaction);
            var sql = $@"SELECT * FROM crb.currency WHERE ""NumericCode""=@code and ""Date""='{date.Value:dd/MM/yyyy}' LIMIT 1";
            var result = conn.QuerySingleOrDefault<CurrencyDTO>(sql, new {code}, transaction);
            return result;
        }

        public CurrencyDTO CheckItemInDb(CurrencyDTO item, IDbTransaction transaction = null)
        {
            using var connection = _connFactory.GetConnection(transaction);
            var result = SearchByAlphaCode(item.AlphaCode, item.Date, transaction) ?? SearchByNumericCode(item.NumericCode, item.Date, transaction);
            return result;
        }

        public bool CheckLastDate(IDbTransaction transaction = null)
        {
            using var connection = _connFactory.GetConnection(transaction);
            var sql = $@"SELECT ""Date"" FROM crb.currency ORDER BY ""Date"" DESC LIMIT 1";
            var result = connection.QuerySingleOrDefault<DateTime>(sql, new { }, transaction);
            return result == DateTime.Today;
        }
    }
}
    