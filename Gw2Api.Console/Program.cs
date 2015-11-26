using NodaTime;

namespace Gw2Api.ConsoleApp
{
    using System;

    using Core;

    using ShortStack.Core;

    class Program
    {
        static void Main(string[] args)
        {
            ShortStack.BootStack();
            var getCharacterNamesForAccount = ShortStack.Container.GetInstance<GetCharacterNamesForAccount>();
            var getCharacterInformation = ShortStack.Container.GetInstance<GetCharacterInformation>();
            
            string key = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

            var response = getCharacterNamesForAccount.HandleRequest(key);
            
            foreach (var name in response.Names)
            {
                var info = getCharacterInformation.HandleRequest(name, key);
                
                Console.WriteLine("{0} was created on {1}", name, info.Birthday.Date);
            }

            Console.ReadLine();
        }
    }
}
