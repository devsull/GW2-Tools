using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace Gw2Api.Core.EndPoints
{
    public abstract class BaseGw2ApiEndPoint<T> where T : new()
    {
        private readonly Settings settings;

        private readonly RestClient restClient;

        protected string ApiEndPoint { get; set; }

        protected Dictionary<string, List<string>> ApiQueryParams { get; set; } = new Dictionary<string, List<string>>();

        protected List<string> ApiResources { get; set; } =  new List<string>();
        
        protected BaseGw2ApiEndPoint(Settings settings, RestClient restClient)
        {
            this.settings = settings;
            this.restClient = restClient;
        }
        
        protected T Execute(string apiKey = null)
        {
            if (this.ApiEndPoint == null)
            {
                throw new InvalidOperationException("Api end point not specified in an implementation of BaseGw2ApiEndPoint");
            }

            // start end point building
            var endPointBuilder = new StringBuilder(this.ApiEndPoint);
            
            // append any resources to the end point
            foreach (var resourceString in this.ApiResources)
            {
                endPointBuilder.Append("/").Append(resourceString);
            }

            // create request with built api end point
            var request = new RestRequest(endPointBuilder.ToString());

            // append access token if auth needed
            if (apiKey != null)
            {
                request.AddParameter("access_token", apiKey);
            }

            foreach (var apiQueryParam in this.ApiQueryParams)
            {
                var values = string.Join(",", apiQueryParam.Value);
                request.AddParameter(apiQueryParam.Key, values);
            }

            // configure client for api
            var builder = new StringBuilder(this.settings.ApiRootUrl).Append("/").Append(this.settings.ApiVersion);
            this.restClient.BaseUrl = new Uri(builder.ToString());

            // execute request on client
            var response = this.restClient.Execute<T>(request);
            
            // return the data in response
            return response.Data;
        }
    }
}
