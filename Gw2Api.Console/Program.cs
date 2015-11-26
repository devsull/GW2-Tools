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
            var command = ShortStack.Container.GetInstance<GetAccountCharacterNames>();
            
            string key = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

            var names = command.Execute(key);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();
        }
    }
}
