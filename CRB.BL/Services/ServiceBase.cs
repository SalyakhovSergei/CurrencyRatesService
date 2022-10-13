using CRB.DA.Models;
using Serilog;

namespace CRB.BL.Services
{
    public class ServiceBase
    {
        public void LogInformation(ResponseModel item)
        {
            if (item.Code is null || item.Price is null)
            {
                Log.Warning("Nothing found");
            }
            else
            {
                Log.Information($"Get request result for {item.Code}");
            }
        }
    }
}