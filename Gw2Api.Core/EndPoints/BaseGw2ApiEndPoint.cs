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
    using System.Text;
    using RestSharp;

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
        /// Settings contains the API url and version.
        /// </summary>
        private readonly Settings settings;

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
            this.settings = settings;
            this.restClient = restClient;
        }
        
        /// <summary>
        /// Executes the API call by building the request and returning the data from the request.
        /// </summary>
        /// <param name="apiKey">
        /// Guild wars 2 API key, API calls with authorization will require this.
        /// </param>
        /// <returns>
        /// The data from the response casted to type T
        /// </returns>
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
