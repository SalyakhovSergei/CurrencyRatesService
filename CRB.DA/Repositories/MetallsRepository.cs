using System;
using System.Data;
using System.Threading.Tasks;
using CENTROS.Core.DA.Interfaces;
using CENTROS.Core.DA.PgSql;
using CRB.DA.DTO;
using CRB.DA.Interfaces;
using Dapper;
using Serilog;

namespace CRB.DA.Repositories
{
    public class MetallsRepository: IMetallRepository
    {
        private readonly IConnectionFactory _connFactory;

        public MetallsRepository(IConnectionFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public async Task<int> CreateAsync(MetallDTO item, IDbTransaction transaction = null)
        {
            try
            {
                using var conn = _connFactory.GetConnection(transaction);
                if (CheckItemInDb(item)?.Date != item.Date)
                {
                    var id = await conn.InsertSingleAsync(item, r => r.Id, transaction, tableName: "crb.metall");
                    return id;
                }
                if (CheckItemInDb(item)?.Date == item.Date && CheckItemInDb(item)?.Price != item.Price)
                {
                    var id = await conn.InsertSingleAsync(item, r => r.Id, transaction, tableName: "crb.metall");
                    return id;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            return 0;
        }

        public MetallDTO SearchByCode(string code, DateTimeOffset? date, IDbTransaction transaction = null)
        {
            using var conn = _connFactory.GetConnection(transaction);
            var sql = $@"SELECT * FROM crb.metall WHERE ""AlphaCode""=@code and ""Date""='{date.Value:dd/MM/yyyy}' LIMIT 1";
            var result = conn.QuerySingleOrDefault<MetallDTO>(sql, new { code }, transaction);
            return result;
            
        }

        public MetallDTO CheckItemInDb(MetallDTO item, IDbTransaction transaction = null)
        {
            using var connection = _connFactory.GetConnection(transaction);
            return SearchByCode(item.AlphaCode, item.Date, transaction);
        }

        public bool CheckLastDate(IDbTransaction transaction = null)
        {
            using var connection = _connFactory.GetConnection(transaction);
            var sql = $@"SELECT ""Date"" FROM crb.metall ORDER BY ""Date"" DESC LIMIT 1";
            var result = connection.QuerySingleOrDefault<DateTime>(sql, new { }, transaction);
            return result == DateTime.Today;
        }
    }
}