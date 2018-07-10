﻿using System;
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
                            //TODO: Selects a Wallet Instance
                                Display.PrintSelectWallet();
                                Console.ReadLine();
                            break;
                            case "--add-receive":
                            //TODO Adds an object to the model
                                Display.PrintAddNewReceive();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--add-spending":
                            //TODO: Adds a spending to the model
                                Display.PrintAddNewSpending();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--add-wallet":
                            //TODO: Adds a wallet
                                Display.PrintAddNewWallet();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--add-transfer":
                            //TODO: Adds a transfer between the current wallet instance to another wallet registred in the model
                                Display.PrintAddNewTransfer();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-wallets":
                            //TODO: Display last wallets
                                Display.PrintWallets();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-tags":
                            //TODO: Display last tags
                                Display.PrintTags();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-receives":
                            //TODO: Display the last receives
                                Display.PrintReceives();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-transactions":
                            //TODO: Displays the Last Transactions
                                Display.PrintTransactions();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-info":
                            //TODO: Display user info
                                Display.PrintUserInfo();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--help":
                                Display.PrintHelp();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--quit": 
                                Display.PrintMenuQuitMessage();
                                looping = false;        
                            break;
                            default:
                                Console.WriteLine("Option invalid! Please check help section");
                                Display.PrintHelp();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }            
            }

            Console.ReadLine();
        }
    }
}
