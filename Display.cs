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
            Console.Write("Do you want add Tag label to this receive (y/n)? ");
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
               Program.Wallets[Program.CurrentWalletIndex].Deposit(receive);
            }
            else
            {
                Transaction receive = new Transaction(value, description, type, Program.Wallets[Program.CurrentWalletIndex]);
                Program.Transactions.Add(receive);
                Program.Wallets[Program.CurrentWalletIndex].Deposit(receive);
            }
            Console.WriteLine("Receive added sucessfully ! .. :D  ");
            Console.WriteLine();
        }
        public static void PrintAddNewSpending()
        {
            Console.WriteLine("You've selected to add a new spending to this model .. ");
            BusinessRules.ChecksIfWalletIsSelected(); //Checks if exist a valid wallet selectd in the Program.cs
            Console.WriteLine($"You want add a spending to wallet {Program.Wallets[Program.CurrentWalletIndex].Name} :");
            Console.Write("Value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Description: ");
            string description = Console.ReadLine();
            TransactionType type = TransactionType.Spending;
            Console.Write("Do you want add Tag label to this spending (y/n)? ");
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
               Transaction spending = new Transaction(value, description, type, Program.Wallets[Program.CurrentWalletIndex], searchedTag);
               Program.Transactions.Add(spending);
               Program.Wallets[Program.CurrentWalletIndex].Deposit(spending);
            }
            else
            {
                Transaction spending = new Transaction(value, description, type, Program.Wallets[Program.CurrentWalletIndex]);
                Program.Transactions.Add(spending);
                Program.Wallets[Program.CurrentWalletIndex].Deposit(spending);
            }
            Console.WriteLine("Spending added sucessfully ! .. :D  ");
            Console.WriteLine();
        }
        public static void PrintAddNewTransfer()
        {
            throw new NotImplementedException("This function is not implemented!, please contatc the system developer.");
        }
        public static void PrintAddNewWallet()
        {
            Console.WriteLine("You've selected to add a new wallet to this model ... please inform some informations: ");
            BusinessRules.ChecksIfAnUserIsSelected();
            Console.WriteLine($"Do you want add a new wallet to the user {Program.Users[Program.CurrentUserIndex]}");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Wallet wallet = new Wallet(name, Program.Users[Program.CurrentUserIndex]);
            Program.Wallets.Add(wallet);
            Console.WriteLine();
            Console.WriteLine($"Wallet {wallet} added sucessfully to this model :D !  ");
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
        public static void PrintTransaction(Transaction transaction)
        {
             ConsoleColor auxForeGroundColor = Console.ForegroundColor;
                switch(transaction.Type)
                {
                    case TransactionType.Receive:     
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(transaction);
                        
                    break;
                    case TransactionType.Spending:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(transaction);
                    break;
                    case TransactionType.Transfering:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(transaction);
                    break;
                }
               Console.ForegroundColor = auxForeGroundColor;
        }
        public static void PrintTransactions()
        {
            BusinessRules.ChecksIfWalletIsSelected(); //Checks if exist a valid wallet selectd in the Program.cs
            Console.WriteLine("Displaying all transactions: ");
            foreach(Transaction p in Program.Transactions.Where( x => x.Origin == Program.Wallets[Program.CurrentWalletIndex]))
            {
               PrintTransaction(p);
            }
        }
        public static void PrintSpending()
        {
            BusinessRules.ChecksIfWalletIsSelected(); //Checks if exist a valid wallet selectd in the Program.cs
            Console.WriteLine("Displaying all spendings: ");
            foreach(Transaction p in Program.Transactions.Where( x => x.Type == TransactionType.Spending && x.Origin == Program.Wallets[Program.CurrentWalletIndex]))
            {
               PrintTransaction(p);
            }
        }
        public static void PrintReceives()
        {
            BusinessRules.ChecksIfWalletIsSelected(); //Checks if exist a valid wallet selectd in the Program.cs
            Console.WriteLine("Displaying all receives: ");
            foreach(Transaction p in Program.Transactions.Where( x => x.Type == TransactionType.Receive && x.Origin == Program.Wallets[Program.CurrentWalletIndex]))
            {
               PrintTransaction(p);
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
            Console.WriteLine("Wallets:  ");
            Console.WriteLine();
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
            Console.WriteLine();
        }
        public static void PrintNonCommandValid()
        {
            Console.WriteLine();
            Console.WriteLine("Command typed is invalid.. please try typing --help to view the commands accepted.");
            Console.WriteLine();
        }
        public static void PrintTypeAnyKeyToConitinue()
        {
            Console.WriteLine();
            Console.Write("Please type any key to continue.");
            Console.ReadLine();
        }
        public static void PrintHelp()
        {
            Console.WriteLine("You can type the following commands: ");
            Console.WriteLine("--select-walet               | Selects a wallet insrance in this model");
            Console.WriteLine("--add-receive                | Adds a receive to the wallet instance in the program");
            Console.WriteLine("--add-spending               | Adds a spending to the wallet instance in the program");
            Console.WriteLine("--display-transactions       | Displays all transactions registered in the wallet instance selected");
            Console.WriteLine("--display-wallets            | Displays all wallets");
            Console.WriteLine("--display-tags               | Displays all tags registered in the system");
        }
   
    }
}