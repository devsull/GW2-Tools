// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCharacterInformation.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Base class for implementing Gw2ApiEndPoints, to be used in conjunction with an interface of 
//   either IGw2ApiEndPoint or IGw2ApiAuthEndPoint, for unauthorized and authorized end points
//   respectively.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    using Gw2Api.Core.GW2ApiRawObjects;

    using Newtonsoft.Json;

    using RestSharp;
    using RestSharp.Deserializers;

    using ShortStack.Core;

    /// <summary>
    /// Base class for implementing Gw2ApiEndPoints, to be used in conjunction with an interface of 
    /// either IGw2ApiEndPoint or IGw2ApiAuthEndPoint, for unauthorized and authorized end points
    /// respectively.
    /// </summary>
    /// <typeparam name="T">
    /// The type of data the end point will return.
    /// </typeparam>
    public abstract class BaseGw2ApiEndPoint<T> where T : new()
    {
        /// <summary>
        /// The guild wars 2 API key query parameter name.
        /// </summary>
        private const string ApiKeyQueryParamName = "access_token";
        
        /// <summary>
        /// The client we'll use to make the API calls.
        /// </summary>
        private readonly RestClient restClient;

        /// <summary>
        /// Sets the API end point that we will hit.
        /// </summary>
        protected string ApiEndPoint { get; set; }

        /// <summary>
        /// Holds the params to appends to the end of an API call.
        /// </summary>
        protected Dictionary<string, List<string>> ApiQueryParams { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// Houses the API resources needed to make the call.
        /// ie: "http://apiUrl.com/version/endpoint/{resource1}/{resource2}/" etc
        /// </summary>
        protected List<string> ApiResources { get; set; } =  new List<string>();
        
        /// <summary>
        /// Base Guild Wars 2 API end point.
        /// </summary>
        /// <param name="settings">
        /// Settings contains the API url and version.
        /// </param>
        /// <param name="restClient">
        /// The client we'll use to make the API calls.
        /// </param>
        protected BaseGw2ApiEndPoint(Settings settings, RestClient restClient)
        {
            this.restClient = restClient;

            // configure our rest client for api
            this.restClient.BaseUrl = BuildRootGw2ApiUri(settings);
        }

        /// <summary>
        /// Executes the API call by building the request and returning the data from the request.
        /// </summary>
        /// <param name="apiKey">
        ///     Guild wars 2 API key, API calls with authorization will require this.
        /// </param>
        /// <returns>
        /// The data from the response cast to type T
        /// </returns>
        protected Gw2ApiResponse<T> Execute(string apiKey = null)
        {
            var request = this.BuildGw2ApiRequest(apiKey);
            
            return this.HandleRequest(request);
        }

        private Gw2ApiResponse<T> HandleRequest(IRestRequest request)
        {
            var restClientResponse = this.restClient.Execute<T>(request);

            var errorMessages = this.GetErrorMessagesInResponse(restClientResponse);
            
            var response = new Gw2ApiResponse<T> { ErrorMessages = errorMessages };

            if (!response.ErrorMessages.Any())
            {
                response.Data = restClientResponse.Data;
            }

            return response;
        }

        private List<string> GetErrorMessagesInResponse(IRestResponse<T> restClientResponse)
        {
            var errorMessages = new List<string>();

            if (restClientResponse.StatusCode == HttpStatusCode.OK || restClientResponse.StatusCode == HttpStatusCode.PartialContent)
            {
                return errorMessages;
            }

            // get rest client errors
            if (!string.IsNullOrEmpty(restClientResponse.ErrorMessage))
            {
                errorMessages.Add(restClientResponse.ErrorMessage);
            }

            // get gw2 api errors
            var message = JsonConvert.DeserializeObject<ErrorMessage>(restClientResponse.Content);
            errorMessages.Add(message.Text);

            return errorMessages;
        }

        /// <summary>
        /// Build the root Guild Wars 2 API end point
        /// </summary>
        /// <returns>
        /// The api end point with the base url and version of the GW2 API.
        /// </returns>
        private static Uri BuildRootGw2ApiUri(Settings settings)
        {
            var builder = new StringBuilder(settings.ApiRootUrl).Append("/").Append(settings.ApiVersion);

            return new Uri(builder.ToString());
        }
        
        /// <summary>
        /// Build the request for getting information from the GW2 API.
        /// </summary>
        /// <param name="apiKey">
        /// GW2 API key for authenticated requests.
        /// </param>
        /// <returns></returns>
        private IRestRequest BuildGw2ApiRequest(string apiKey)
        {
            // create request with built api end point
            var request = new RestRequest(this.BuildGw2ApiEndPoint());
            
            // append access token if auth needed
            if (apiKey != null)
            {
                request.AddParameter(ApiKeyQueryParamName, apiKey);
            }
            
            // append query params
            foreach (var apiQueryParam in this.ApiQueryParams)
            {
                var values = string.Join(",", apiQueryParam.Value);
                request.AddParameter(apiQueryParam.Key, values);
            }

            return request;
        }

        /// <summary>
        /// Throws exceptions if the implemented end point is not sane.
        /// </summary>
        private void CheckEndPointSanity()
        {
            // all end points should be declared
            if (this.ApiEndPoint == null)
            {
                throw new ArgumentNullException(nameof(this.ApiEndPoint));
            }
        }

        /// <summary>
        /// Build the guild wars 2 api end point for this base api request.
        /// </summary>
        /// <returns>
        /// The built end point specified by the implementation.
        /// </returns>
        private string BuildGw2ApiEndPoint()
        {
            // Let's make sure that the gw2 api end point has been implemented correctly
            this.CheckEndPointSanity();

            var endPointBuilder = new StringBuilder(this.ApiEndPoint);

            // append any resources to the end point
            foreach (var resourceString in this.ApiResources)
            {
                endPointBuilder.Append("/").Append(resourceString);
            }

            return endPointBuilder.ToString();
        }
    }
}
