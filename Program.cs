using System;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;

namespace SimpleWalletConsoleApp
{
    class Program
    {
        private static List<Tag> tags = new List<Tag>();
        static void Main(string[] args)
        {
            tags.Add(new Tag("Google", TagColor.Yellow));
            tags.Add(new Tag("Brazil", TagColor.Green));
            tags.Add(new Tag("Ocean", TagColor.Blue));
            tags.Add(new Tag("RedHat", TagColor.Red));
            Console.WriteLine("Teste tag:");
            Display.PrintTags(tags);
        }
    }
}
