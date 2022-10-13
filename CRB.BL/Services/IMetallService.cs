using System;
using System.Threading.Tasks;
using CRB.DA.Models;

namespace CRB.BL.Services
{
    public interface IMetallService
    {
        Task<int> AddItem(Metall metall);
        ResponseModel GetResponse(string code, DateTime? date);
        bool CheckLastDate();
    }
}