namespace GW2Tools.Core.Birthdays
{
    using System.Collections.Generic;

    using Gw2Api.Core.EndPoints.CharacterInformation;

    public interface ICharacterBirthdays
    {
        List<CharacterInformation> GetBirthdays(string apiKey);
    }
}