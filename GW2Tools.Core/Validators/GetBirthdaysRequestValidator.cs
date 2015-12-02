// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetBirthdaysRequestValidator.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The get birthdays request validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.Validators
{
    using FluentValidation;

    using ShortStack.Core.Validation;

    /// <summary>
    /// The get birthdays request validator.
    /// </summary>
    public class GetBirthdaysRequestValidator : AbstractValidator<GetBirthdaysRequest>, IValidateObjects<GetBirthdaysRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetBirthdaysRequestValidator"/> class.
        /// </summary>
        public GetBirthdaysRequestValidator()
        {
            this.RuleFor(r => r.GuildWars2ApiKey).Must(Gw2AuthApiRequestValidation.LooksLikeGuildWarsTwoAPIKey).WithMessage("Invalid GW2 API access token");
        }
    }
}
