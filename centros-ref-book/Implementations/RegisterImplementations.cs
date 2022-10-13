using CENTROS.Core.DA.Interfaces;
using CENTROS.Core.DA.PgSql;
using ClassLibrary1;
using CRB.BL.ReceivingDataServices.Interfaces;
using CRB.BL.ReceivingDataServices.Services;
using CRB.BL.Services;
using CRB.DA.CacheModel;
using CRB.DA.Interfaces;
using CRB.DA.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace centros_ref_book.Implementations
{
    public static class RegisterImplementations
    {
        public static void RegisterImplementation(this IServiceCollection services)
        {
            //работа с БД
            services.AddSingleton<IConnectionFactory, PgSqlConnectionFactory>();
            services.AddSingleton<IConnectionResolver, PgSqlConnectionResolver>();

            //работа с данными
            services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
            services.AddSingleton<IMetallRepository, MetallsRepository>();
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<IMetallService, MetallsService>();
            services.AddSingleton<ICacheModel, CacheModel>();

            services.AddMemoryCache();

            //работа с источником
            services.AddSingleton<IMetallReciever, MetallReceiver>();
            services.AddSingleton<ICurrencyReceiver, CurrencyReceiver>();
            
            DapperCustomExtensions.SetFormatter(new PostgresAdapter());
        }
    }
}
