// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountCharacterNames.cs" company="Devin Sullivan">
//   I made this!
// </copyright>
// <summary>
//   The get account character names will get all the names of your gw2 characters on your account. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RestSharp;

    /// <summary>
    /// The get account character names.
    /// </summary>
    public class GetAccountCharacterNames
    {
        private readonly Settings settings;

        private readonly RestClient restClient;

        private readonly string apiEndPoint;
        
        public GetAccountCharacterNames(Settings settings, RestClient restClient)
        {
            this.settings = settings;
            this.restClient = restClient;

            this.apiEndPoint = "characters";
        }

        public List<string> Execute(string apiKey)
        {
            var request = this.BuildRestRequest(apiKey);

            var builder = new StringBuilder(this.settings.ApiRootUrl).Append("/").Append(this.settings.ApiVersion);

            this.restClient.BaseUrl = new Uri(builder.ToString());

            var response = this.restClient.Execute<List<string>>(request);

            var nameList = response.Data;

            return nameList;
        }

        private RestRequest BuildRestRequest(string apiKey)
        {
            var request = new RestRequest(this.apiEndPoint);
            
            request.AddParameter("access_token", apiKey);

            return request;
        }
    }
}
