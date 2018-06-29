using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Models.Financial;


namespace SimpleWalletConsoleApp
{
    public class Debug
    {
        public static void AddDebugSamples()
        {
            Program.Users.Add(new SystemUser("Rafael Borges", "simplewaladmin", "teste123"));
            Program.Users.Add(new SystemUser("Athan Gray", "agray55", "teste123"));
            Program.Wallets.Add(new Wallet("CITI Bank", Program.Users[0]));
            Program.Wallets.Add(new Wallet("Itau Bank", Program.Users[0]));

            Program.Tags.Add(new Tag("Food", TagColor.Red));
            Program.Tags.Add(new Tag("Housing", TagColor.Green));
            Program.Tags.Add(new Tag("Health", TagColor.Blue));
            Program.Tags.Add(new Tag("Bills", TagColor.Yellow));
        }
    }
}