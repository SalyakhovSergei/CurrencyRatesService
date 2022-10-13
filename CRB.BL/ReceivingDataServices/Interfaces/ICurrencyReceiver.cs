using System.Threading.Tasks;

namespace CRB.BL.ReceivingDataServices.Interfaces
{
    public interface ICurrencyReceiver
    {
        Task<string> GetCurrency();
    }
}