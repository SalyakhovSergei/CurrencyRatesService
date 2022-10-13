using System;
using System.Data;
using System.Threading.Tasks;
using CRB.DA.DTO;

namespace CRB.DA.Interfaces
{
    public interface IMetallRepository
    {
        Task<int> CreateAsync(MetallDTO item, IDbTransaction transaction = null);
        MetallDTO SearchByCode(string code, DateTimeOffset? date, IDbTransaction transaction = null);
        bool CheckLastDate(IDbTransaction transaction = null);
    }
}