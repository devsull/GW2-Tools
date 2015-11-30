
using Newtonsoft.Json;

namespace Gw2Api.ConsoleApp
{
    using System;
    using ShortStack.Core;
    using GW2Tools.Core;

    class Program
    {
        static void Main(string[] args)
        {
            ShortStack.BootStack();

            var birthdayStuff = ShortStack.Container.GetInstance<ICharacterBirthdays>();

            string key = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

            var info = birthdayStuff.GetBirthdays(key);

            var json = JsonConvert.SerializeObject(info);

            Console.WriteLine(json);
            Console.ReadLine();
        }

        //private static void displayBirthdays(string key)
        //{
        //    var getCharacterNamesForAccount = ShortStack.Container.GetInstance<GetAccountCharacterNames>();
        //    var getCharacterInformation = ShortStack.Container.GetInstance<GetCharacterInformation>();

        //    var response = getCharacterNamesForAccount.HandleRequest(key);

        //    foreach (var name in response.Names)
        //    {
        //        var info = getCharacterInformation.HandleRequest(name, key);

        //        var json = JsonConvert.SerializeObject(info);

        //        Console.WriteLine(json);
        //    }
        //}
    }
}
