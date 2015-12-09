// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetBirthdaysCommand.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The get birthdays command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.Birthdays
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gw2Api.Core.EndPoints;
    using Gw2Api.Core.EndPoints.AccountCharacterNames;
    using Gw2Api.Core.EndPoints.CharacterInformation;

    using ShortStack.Core.Commands;
    using ShortStack.Core.Validation;

    /// <summary>
    /// The get birthdays command.
    /// </summary>
    public class GetBirthdaysCommand : BaseCommand<GetBirthdaysRequest, List<CharacterInformation>>
    {
        /// <summary>
        /// The account character names end point.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<AccountCharacterNames> accountCharacterNamesEndPoint;

        /// <summary>
        /// The character information end point.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<CharacterInformation> characterInformationEndPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBirthdaysCommand"/> class.
        /// </summary>
        /// <param name="validator">
        /// The validator.
        /// </param>
        /// <param name="accountCharacterNamesEndPoint">
        /// The account character names end point.
        /// </param>
        /// <param name="characterInformationEndPoint">
        /// The character information end point.
        /// </param>
        public GetBirthdaysCommand(
            IValidateObjects<GetBirthdaysRequest> validator,
            IGw2ApiAuthEndPoint<AccountCharacterNames> accountCharacterNamesEndPoint,
            IGw2ApiAuthEndPoint<CharacterInformation> characterInformationEndPoint)
            : base(validator)
        {
            this.accountCharacterNamesEndPoint = accountCharacterNamesEndPoint;
            this.characterInformationEndPoint = characterInformationEndPoint;
        }

        /// <summary>
        /// Gets the character names for and account then makes gets each character's information through the GW2 API
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        protected override List<CharacterInformation> HandleRequest()
        {
            var characters = this.accountCharacterNamesEndPoint.HandleRequest(this.Request.GuildWars2ApiKey);

            var names = characters.Data.Names;
            if (names == null)
            {
                return null;
            }

            var response = new List<CharacterInformation>();

            Parallel.ForEach(
                names,
                (name) =>
                response.Add(this.characterInformationEndPoint.HandleRequest(this.Request.GuildWars2ApiKey, name).Data));

            return response.OrderBy(c => c.DaysUntilBirthday).ToList();
        }
    }
}
