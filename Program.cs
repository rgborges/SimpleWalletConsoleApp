using System;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;

namespace SimpleWalletConsoleApp
{
    class Program
    {
        private static List<Tag> Tags = new List<Tag>();
        private static List<SystemUser> Users = new List<SystemUser>();
        static void Main(string[] args)
        {
            // tags.Add(new Tag("Google", TagColor.Yellow));
            // tags.Add(new Tag("Brazil", TagColor.Green));
            // tags.Add(new Tag("Ocean", TagColor.Blue));
            // tags.Add(new Tag("RedHat", TagColor.Red));
            // Console.WriteLine("Teste tag:");
            // Display.PrintTags(tags);

            Users.Add(new SystemUser("Alex Shultz", "ashultz", "1234"));
            Users.Add(new SystemUser("Evan Nails", "enail", "1234"));
            Users.Add(new SystemUser("Daniel Rian", "drian", "1234"));
            Users.Add(new SystemUser("Marre Allison", "malison", "1234"));

            Display.PrintSystemUsers(Users);

            Console.ReadLine();
        }
    }
}
