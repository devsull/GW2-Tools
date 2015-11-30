using System.Collections.Generic;
using Gw2Api.Core.EndPoints.CharacterInformation;

namespace GW2Tools.Core
{
    public interface ICharacterBirthdays
    {
        List<CharacterInformation> GetBirthdays(string apiKey);
    }
}