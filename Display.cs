using System;
using System.Collections.Generic;
using System.Linq;

using SimpleWalletConsoleApp.Models;
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
            Console.Clear();
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
    }
}