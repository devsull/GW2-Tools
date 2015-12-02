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

    public class GetBirthdaysCommand : BaseCommand<GetBirthdaysRequest, List<CharacterInformation>>
    {
        private readonly IGw2ApiAuthEndPoint<AccountCharacterNames> accountCharacterNamesEndPoint;

        private readonly IGw2ApiAuthEndPoint<CharacterInformation> characterInformationEndPoint;

        public GetBirthdaysCommand(IValidateObjects<GetBirthdaysRequest> validator, IGw2ApiAuthEndPoint<AccountCharacterNames> accountCharacterNamesEndPoint, IGw2ApiAuthEndPoint<CharacterInformation> characterInformationEndPoint)
            : base(validator)
        {
            this.accountCharacterNamesEndPoint = accountCharacterNamesEndPoint;
            this.characterInformationEndPoint = characterInformationEndPoint;
        }

        protected override List<CharacterInformation> HandleRequest()
        {
            var characters = this.accountCharacterNamesEndPoint.HandleRequest(this.Request.GuildWars2ApiKey);

            if (characters.Names == null)
            {
                return null;
            }

            var response = new List<CharacterInformation>();

            //// lets make all of our api calls in parallel
            //var apiCalls = characters.Names.Select(
            //    name =>
            //    new Task<CharacterInformation>(
            //        () => this.characterInformationEndPoint.HandleRequest(this.Request.GuildWars2ApiKey, name)))
            //    .ToArray();

            //var apiCallsDone = Task.WhenAll(apiCalls);

            //response = apiCallsDone.Result.ToList();

            //return response.OrderBy(c => c.DaysUntilBirthday).ToList();

            Parallel.ForEach(
                characters.Names,
                (name) =>
                response.Add(this.characterInformationEndPoint.HandleRequest(this.Request.GuildWars2ApiKey, name)));
            //{
            //    var characterInfo = this.characterInformationEndPoint.HandleRequest(this.Request.GuildWars2ApiKey, name);
            //    response.Add(characterInfo);
            //}

            return response.OrderBy(c => c.DaysUntilBirthday).ToList();
        }
    }
}
