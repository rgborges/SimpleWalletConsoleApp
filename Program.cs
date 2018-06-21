using System;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;

namespace SimpleWalletConsoleApp
{
    class Program
    {
        public static List<Tag> Tags = new List<Tag>();
        public static List<SystemUser> Users = new List<SystemUser>();
        public static List<Wallet> Wallets = new List<Wallet>();
        public static List<Transaction> Transactions = new List<Transaction>();
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

            

            Wallets.Add(new Wallet("Nubank", Users[0], 1));

            Transactions.Add(new Transaction(12.90, "Bank", Wallets[0]));
            Transactions.Add(new Transaction(20.6, "Tax", Wallets[0]));

            Wallets[0].ImportTransactions(Transactions);

            Display.PrintWalletTransactions();


        

            Console.ReadLine();
        }
    }
}
