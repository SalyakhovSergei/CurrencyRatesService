using System;
using System.Data;
using System.Threading.Tasks;
using CRB.DA.DTO;

namespace CRB.DA.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<int> CreateAsync(CurrencyDTO item, IDbTransaction transaction = null);
        CurrencyDTO SearchByAlphaCode(string code, DateTimeOffset? date, IDbTransaction transaction = null);
        CurrencyDTO SearchByNumericCode(string code, DateTimeOffset? date, IDbTransaction transaction = null);
        bool CheckLastDate (IDbTransaction transaction = null);
    }
}