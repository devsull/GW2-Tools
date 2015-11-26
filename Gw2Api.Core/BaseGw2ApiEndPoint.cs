using System;
using System.Text;
using RestSharp;

namespace Gw2Api.Core
{
    public abstract class BaseGw2ApiEndPoint<T> where T : new()
    {
        private readonly Settings settings;

        private readonly RestClient restClient;

        private readonly string apiEndPoint;
        
        protected BaseGw2ApiEndPoint(Settings settings, RestClient restClient, string endPoint)
        {
            this.settings = settings;
            this.restClient = restClient;
            this.apiEndPoint = endPoint;
        }

        protected T Execute(string apiKey = null, string[] resourceStrings = null)
        {
            if (this.apiEndPoint == null)
            {
                throw new InvalidOperationException("Api end point not specified in an implementation of BaseGw2ApiEndPoint");
            }

            var endPointBuilder = new StringBuilder(this.apiEndPoint);

            if (resourceStrings != null)
            {
                foreach (var resourceString in resourceStrings)
                {
                    endPointBuilder.Append("/").Append(resourceString);
                }
            }

            var request = new RestRequest(endPointBuilder.ToString());

            if (apiKey != null)
            {
                request.AddParameter("access_token", apiKey);
            }

            var builder = new StringBuilder(this.settings.ApiRootUrl).Append("/").Append(this.settings.ApiVersion);

            this.restClient.BaseUrl = new Uri(builder.ToString());

            var response = this.restClient.Execute<T>(request);
            
            return response.Data;
        }
    }
}
