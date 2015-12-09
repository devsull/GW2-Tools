// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountInventoryRequestValidator.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The get account inventory request validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.Validators
{
    using AccountInventory;

    using FluentValidation;

    using ShortStack.Core.Validation;

    /// <summary>
    /// The get account inventory request validator.
    /// </summary>
    public class GetAccountInventoryRequestValidator : AbstractValidator<GetAccountInventoryRequest>, IValidateObjects<GetAccountInventoryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountInventoryRequestValidator"/> class.
        /// </summary>
        public GetAccountInventoryRequestValidator()
        {
            this.RuleFor(r => r.GuildWars2ApiKey).Must(Gw2AuthApiRequestValidation.LookLikeAValidGuildWarsTwoApiKey).WithMessage("Invalid GW2 API access token");
        }
    }
}
