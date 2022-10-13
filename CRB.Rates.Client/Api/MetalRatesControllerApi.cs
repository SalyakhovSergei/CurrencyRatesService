using System;
using System.Collections.Generic;
using CRB.Rates.Client.Client;
using CRB.Rates.Client.Model;
using RestSharp;

namespace CRB.Rates.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMetalRatesControllerApi
    {
        /// <summary>
        /// Получение информации по ценам драгоценных металлов Получение информации по ценам драгоценных металлов.
        /// </summary>
        /// <param name="date">Дата получения курса.</param>
        /// <returns>MetalsOnDateResponse</returns>
        MetalsOnDateResponse Metals (DateTime? date);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MetalRatesControllerApi : IMetalRatesControllerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetalRatesControllerApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public MetalRatesControllerApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="MetalRatesControllerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MetalRatesControllerApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Получение информации по ценам драгоценных металлов Получение информации по ценам драгоценных металлов.
        /// </summary>
        /// <param name="date">Дата получения курса.</param>
        /// <returns>MetalsOnDateResponse</returns>
        public MetalsOnDateResponse Metals (DateTime? date)
        {
    
            var path = "/cbr/metal_prices";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (date != null) queryParams.Add("date", ApiClient.ParameterToString(date)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Metals: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Metals: " + response.ErrorMessage, response.ErrorMessage);
    
            return (MetalsOnDateResponse) ApiClient.Deserialize(response.Content, typeof(MetalsOnDateResponse), response.Headers);
        }
    
    }
}
