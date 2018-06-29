using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Models.Financial;


namespace SimpleWalletConsoleApp
{
    class Display
    {
        public static void PrintHeader(string header)
        {
            Console.Clear();
            Console.WriteLine("Borges Sofwtare Labs - v 0.0.1 - SimpleWallet Console App 2018");
            Console.WriteLine();
            Console.Write($"{header}>");
        }
        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Borges Sofwtare Labs - v 0.0.1 - SimpleWallet Console App 2018");
            Console.WriteLine();
            Console.WriteLine("Please type an option: ");
            Console.WriteLine(" 1. List Tags"); 
            Console.WriteLine(" 2. Add a Tag");
            Console.WriteLine(" 3. List Wallets");
            Console.WriteLine(" 4. List Transactions");
            Console.WriteLine(" 5. Add Transactions");
            Console.WriteLine();
            Console.Write("Please type an option: ");
        }
        public static void PrintTagManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("Borges Sofwtare Labs - v 0.0.1 - SimpleWallet Console App 2018");
            Console.WriteLine();
            Console.WriteLine("Please type an option: ");
            Console.WriteLine(" 1. List Tags"); 
            Console.WriteLine(" 2. Add a Tag");
            Console.WriteLine(" 3. Edit a Tag");
            Console.WriteLine(" 4. Remove a Tag");
            Console.WriteLine(" 5. Come back");
            Console.WriteLine();
            Console.Write("Please type an option: ");
        }
        public static void PrintSelectWallet()
        {
            Console.WriteLine();
            Console.WriteLine("You want to select a wallet instance to the workspace .. :");
            Console.WriteLine();
            PrintWallets();
            Console.Write("Please select your wallet GUID: ");
            Guid guidSearched = Guid.Parse(Console.ReadLine());
            int walletSearchedIndex = Program.Wallets.FindIndex( x => x.Id == guidSearched);
            if(walletSearchedIndex == -1)
            {
                throw new BusinessException("Business Error: Wallet guid not found ! please try again ..");
            }
            Program.CurrentWalletIndex = walletSearchedIndex;
            Console.WriteLine($"You've selected the following wallet in the worksapce: {Program.Wallets[Program.CurrentWalletIndex]}");
            Console.WriteLine();
            ProgramMechanics.UpdateHeader(Program.Wallets[Program.CurrentWalletIndex].Name);
        }
        public static void PrintSystemWallets()
        {
             Console.WriteLine();
             Console.WriteLine("Printing wallets registered in the system ... :");
             foreach(Wallet p in Program.Wallets)
             {
                 Console.WriteLine(p);
             }
             Console.WriteLine();
        }
        public static void PrintAddNewReceive()
        {
            Console.WriteLine("You've selected to add a new receive to this model .. ");
            BusinessRules.ChecksIfWalletIsSelected(); //Checks if exist a valid wallet selectd in the Program.cs
            Console.WriteLine($"You want add a receive to wallet {Program.Wallets[Program.CurrentWalletIndex].Name} :");
            Console.Write("Value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Description: ");
            string description = Console.ReadLine();
            TransactionType type = TransactionType.Receive;
            Console.WriteLine("Do you want add Tag label to this receive (y/n)? ");
            char answer = char.Parse(Console.ReadLine());
            if(answer == 'y')
            {
               Console.Write("Select the Tag Name : ");
               string tagName = Console.ReadLine();
               Console.WriteLine("Searching in the tag list .. ");
               Tag searchedTag = Program.Tags.Find( x => x.Name == tagName);
               if(searchedTag == null)
               {
                   throw new BusinessException("Tag searched not found ! .. please have right that the tag exist ..  :( ");
               }
               Transaction receive = new Transaction(value, description, type, Program.Wallets[Program.CurrentWalletIndex], searchedTag);
               Program.Transactions.Add(receive);
            }
            else
            {
                Transaction receive = new Transaction(value, description, type, Program.Wallets[Program.CurrentWalletIndex]);
                Program.Transactions.Add(receive);
            }
            Console.WriteLine("Receive added sucessfully ! .. :D  ");
            Console.WriteLine();
        }
        public static void PrintTags()
        {
             var aux = Console.ForegroundColor;
            foreach (Tag p in Program.Tags)
            {
                Console.Write(p);
                Console.Write(", Color: ");
                switch(p.Color)
                {              
                    case TagColor.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Blue");
                        Console.ForegroundColor = aux;
                    break;
                    case TagColor.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Green");
                        Console.ForegroundColor = aux;
                    break;
                       case TagColor.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Yellow");
                        Console.ForegroundColor = aux;
                    break;
                       case TagColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Red");
                        Console.ForegroundColor = aux;
                    break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("White");
                        Console.ForegroundColor = aux;
                    break;
                }
            }
        }
        public static void PrintSystemUsers()
        {
            foreach (SystemUser p in Program.Users)
            {
                Console.WriteLine(p);
            }
        }
        public static void PrintWallets()
        {
            foreach (Wallet p in Program.Wallets)
            {
                Console.WriteLine(p);
            }
        }
        public static void PrintWalletTransactions()
        {
            Console.Clear();
            Console.Write("Type the wallet id: ");
            Guid id = Guid.Parse(Console.ReadLine());
            int searchedIdWallet = Program.Wallets.FindIndex(x => x.Id == id);
            if(searchedIdWallet == -1 )
            {
                throw new SimpleWalletException("Was not possible find this wallet Id :(  ... ");
            }
            Console.WriteLine("Wallet: ");
            Console.WriteLine(Program.Wallets[searchedIdWallet]);
            Console.WriteLine("Transactions in this wallet: ");
            foreach (Transaction p in Program.Transactions.Where( x => x.Origin == Program.Wallets[searchedIdWallet]))
            {
                Console.WriteLine(p);
            }
        }
        public static void PrintMenuQuitMessage()
        {
            Console.WriteLine("Exiting the program ...");
            Console.WriteLine("Bye Bye ;D ... Se ya!");
        }
        public static void PrintNonCommandValid()
        {
            Console.WriteLine();
            Console.WriteLine("Command typed is invalid.. please try typing --help to view the commands accepted.");
            Console.WriteLine();
        }
   
    }
}