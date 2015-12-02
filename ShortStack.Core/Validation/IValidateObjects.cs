// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidateObjects.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Interface for validators.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core.Validation
{
    using FluentValidation.Results;

    /// <summary>
    /// Interface for validators.
    /// </summary>
    /// <typeparam name="T">
    /// The object type to validate
    /// </typeparam>
    public interface IValidateObjects<T>
    {
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="objectToValidate">
        /// The object to validate.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        ValidationResult Validate(T objectToValidate);
    }
}