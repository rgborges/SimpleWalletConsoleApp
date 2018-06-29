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
        public static int CurrentWalletIndex, CurrentUserIndex;
        public static string Header = "SimpleWallet";
        static void Main(string[] args)
        {
            //Add debug sample
            Debug.AddDebugSamples();
            bool looping;
            looping = true;
            while(looping == true)
            {
                try
                {
                    Display.PrintHeader(Header);
                    string command = Console.ReadLine();
                    string[] options = command.Split(' ');
                    foreach(var key in options)
                    {
                        switch(key)
                        {
                            case "--select-wallet":
                                if(options.Length == 1 )
                                {
                                    //validates the --select-wallet only command
                                    Display.PrintSelectWallet();
                                    Console.ReadLine();
                                }
                                else
                                {
                                    switch(options[2])
                                    {
                                        case "-w":
                                        break;
                                        default:
                                            Display.PrintNonCommandValid();
                                            Console.ReadLine();
                                        break;
                                    }
                                }
                            break;
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
