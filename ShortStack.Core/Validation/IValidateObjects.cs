// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidateObjects.cs" company="Devin Sullivan">
//   This thing I made.
// </copyright>
// <summary>
//   The ValidateObjects interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core.Validation
{
    using FluentValidation.Results;

    /// <summary>
    /// The ValidateObjects interface.
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