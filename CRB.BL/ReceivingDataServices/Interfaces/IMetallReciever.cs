using System.Threading.Tasks;

namespace CRB.BL.ReceivingDataServices.Interfaces
{
    public interface IMetallReciever
    {
        Task<string> GetMetalls();
    }
}