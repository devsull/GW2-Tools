namespace GW2Tools.Core.Birthdays
{
    using System.Collections.Generic;
    using System.Linq;

    using Gw2Api.Core.EndPoints;
    using Gw2Api.Core.EndPoints.AccountCharacterNames;
    using Gw2Api.Core.EndPoints.CharacterInformation;

    public class CharacterBirthdays : ICharacterBirthdays
    {
        private readonly IGw2ApiAuthEndPoint<AccountCharacterNames> getAccountCharacterNamesEndPoint;
        private readonly IGw2ApiAuthEndPoint<CharacterInformation> getCharacterInformationEndPoint;

        public CharacterBirthdays(IGw2ApiAuthEndPoint<AccountCharacterNames> getAccountCharacterNamesEndPoint, IGw2ApiAuthEndPoint<CharacterInformation> getCharacterInformationEndPoint)
        {
            this.getAccountCharacterNamesEndPoint = getAccountCharacterNamesEndPoint;
            this.getCharacterInformationEndPoint = getCharacterInformationEndPoint;
        }

        public List<CharacterInformation> GetBirthdays(string apiKey)
        {
            // TODO: add validation on api key (maybe implement commands?)
            var characters = this.getAccountCharacterNamesEndPoint.HandleRequest(apiKey);

            var response = new List<CharacterInformation>();
            foreach (var name in characters.Names)
            {
                var chararacter = this.getCharacterInformationEndPoint.HandleRequest(apiKey, name);
                response.Add(chararacter);
            }

            return response.OrderBy(c => c.DaysUntilBirthday).ToList();
        }
    }
}
