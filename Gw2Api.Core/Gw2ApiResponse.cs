// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gw2ApiResponse.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The unauthorized response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core
{
    using System.Collections.Generic;

    using Gw2Api.Core.LookUpValues;

    /// <summary>
    /// The unauthorized response.
    /// </summary>
    public class Gw2ApiResponse<T>
    {
        public T Data { get; set; }

        public List<string> ErrorMessages { get; set; }

        public bool Success => this.ErrorMessages.Count == 0;
    }
}