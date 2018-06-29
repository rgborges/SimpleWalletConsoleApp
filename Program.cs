using System;
using System.Collections.Generic;

using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Models.Financial;


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
            bool looping;
            looping = true;
            while(looping == true)
            {
                try
                {
                    Display.PrintHeader("Simplewallet");
                    string command = Console.ReadLine();
                    string[] options = command.Split(' ');
                    foreach(var key in options)
                    {
                        switch(key)
                        {
                            case "--help":
                                Console.WriteLine("You've typed help!");
                                Console.ReadLine();
                            break;
                            case "--quit":
                            
                            break;
                            default:
                                Console.WriteLine("Option invalid!");
                                Console.ReadLine();
                            break;
                        }
                    }
                }
                catch
                {

                }
                
            }

            Console.ReadLine();
        }
    }
}
