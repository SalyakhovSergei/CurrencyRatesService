using System;
using System.Threading.Tasks;
using CRB.DA.Models;

namespace CRB.BL.Services
{
    public interface ICurrencyService
    {
        Task<int> AddItem(Currency currency);
        ResponseModel GetResponseByAlphaCode(string code, DateTime? date);
        ResponseModel GetResponseByNumericCode(string code, DateTime? date);
        bool CheckLastDate();
    }
}