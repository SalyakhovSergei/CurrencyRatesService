using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using CENTROS.Core.DA.Interfaces;
using CENTROS.Core.DA.PgSql;
using CENTROS.Core.Infrastructure.Security;
using CENTROS.EPA;
using centros_ref_book.Discovery;
using centros_ref_book.Implementations;
using centros_ref_book.Models.Configuration;
using ClassLibrary1;
using CRB.BL.ExternalServices;
using CRB.BL.MappingProfile;
using CRB.BL.Services;
using CRB.DA.AdjustedOptions;
using CRB.DA.Interfaces;
using CRB.DA.Repositories;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Logging;
using Prometheus;
using Prometheus.SystemMetrics;


namespace centros_ref_book
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = _environment.IsDevelopment());

            services.Configure<CacheConfiguration>(Configuration.GetSection("CacheConfiguration"));
            services.Configure<ReceivingConfiguration>(Configuration.GetSection("ReceivingConfiguration"));

            services.RegisterImplementation();
            //services.AddHostedService<CurrencyHostedService>();
            //services.AddHostedService<MetallsHostedServices>();

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

            services.AddSystemMetrics();
            services.AddHealthChecks().ForwardToPrometheus();

            services.AddAutoMapper(typeof(MappingProfile));
            

            var mainOpts = services.AddBaseServiceOptions<SearchAccountsOptions>(Configuration, "ServiceOptions");
            var httpClientOptions = BaseServiceOptionsRegisterExtension.AddServiceOptions<HttpClientOptions>(services, Configuration, "HttpClientWithoutEPA");
            var epaOptions = BaseServiceOptionsRegisterExtension.AddServiceOptions<EPAOptions>(services, Configuration, "EPA");
            epaOptions.ClientSecret = epaOptions.ClientSecret.EncryptDecryptOptionParam("ClientSecret", mainOpts.IsConnectionsEncoded);

            services.WithDefaultEPAProfile()
                .AddEPAService<IAxiomaOMNIcurrencyratesRESTAPIClient, AxiomaOMNIcurrencyratesRESTAPIClient>(mainOpts.HttpClientName, mainOpts.MaxParallelism, mainOpts.CurrencyRatesBaseURL)
                .SetupServiceXTykKeyAuth(mainOpts.CurrencyRatesULXtykKey)
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                    };
                });

            //services.WithEPAProfile("Detail")
            //    .AddEPAService<IAxiomaOMNIcurrencyratesRESTAPIClient, AxiomaOMNIcurrencyratesRESTAPIClient>(mainOpts.HttpClientDetailName, mainOpts.MaxParallelism, mainOpts.AccountFLFindDetailURL)
            //    .SetupServiceXTykKeyAuth(mainOpts.AccountFLXtykKey)
            //    .ConfigurePrimaryHttpMessageHandler(() =>
            //    {
            //        return new HttpClientHandler()
            //        {
            //            ClientCertificateOptions = ClientCertificateOption.Manual,
            //            ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            //        };
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
        ,IApiVersionDescriptionProvider provider, ILogger<Startup> logger)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                logger.LogInformation($"Сервис курсов валют запущен {DateTime.Now}");

                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseHttpMetrics();
                app.UseMetricServer();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapMetrics();
                });

                app.UseSwagger(opts =>
                {
                    opts.SerializeAsV2 = true;
                });

                app.UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
            
        }
    }
}
