using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using centros_ref_book.Models.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using Prometheus;

namespace centros_ref_book.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IHttpClientBuilder AddHttpClientWithoutEPA<TClient, TImplementation>(this IServiceCollection services, 
                                                                 HttpClientOptions options,
                                                                 string clientName,
                                                                 int maxParralles)
            where TClient : class
            where TImplementation : class, TClient
        {
            var throttler = Policy.BulkheadAsync<HttpResponseMessage>(maxParralles, Int32.MaxValue);
            var headersDictionary = GetHeaders(options);
            var jitterer = new Random();
            
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(response => (int)response.StatusCode == 429) // RetryAfter
                .Or<TimeoutRejectedException>() // thrown by Polly's TimeoutPolicy if the inner call times out
                .WaitAndRetryAsync(options.WaitAndRetryDelaysInSeconds
                    .Select(x => TimeSpan.FromSeconds(x) + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000))));

            return services.AddHttpClient<TClient, TImplementation>(clientName, c =>
            {
                c.BaseAddress = new Uri(options.BaseUrl);
                foreach (var (key, value) in headersDictionary)
                {
                    if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value) && !c.DefaultRequestHeaders.Contains(key))
                    {
                        c.DefaultRequestHeaders.Add(key, value);
                    }
                }

            })
                .UseHttpClientMetrics()
                .AddPolicyHandler(throttler)
                .AddPolicyHandler(retryPolicy);
        }

        #region Helpers

        private static Dictionary<string, string> GetHeaders(HttpClientOptions options)
        {
            var headersDictionary = new Dictionary<string, string>();
            var authKeyHeaderName = options.AuthKeyHeaderName;
            //TODO: Сделать шифрование

            var authKeyHeaderValue = options.AuthKeyHeaderValue;
            if (!string.IsNullOrEmpty(authKeyHeaderName) && !string.IsNullOrEmpty(authKeyHeaderValue))
            {
                headersDictionary[authKeyHeaderName] = authKeyHeaderValue;
            }

            return headersDictionary;
        }

        #endregion
    }
}