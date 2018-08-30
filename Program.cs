using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Models.Financial;
using SimpleWalletConsoleApp.Models.Function;


namespace SimpleWalletConsoleApp
{
    class Program
    {
        public static List<Tag> Tags = new List<Tag>();
        public static List<SystemUser> Users = new List<SystemUser>();
        public static List<Wallet> Wallets = new List<Wallet>();
        public static List<Transaction> Transactions = new List<Transaction>();
        public static List<FinancialTask> FinancialTasks = new List<FinancialTask>();
        public static List<FinancialPlan> FinancialPlans = new List<FinancialPlan>();
        public static int CurrentWalletIndex = -1, CurrentUserIndex = -1, CurrentFinancialTaskId = -1, CurrentFinancialPlanId = -1;
        public static string Header = Settings.ApplicationName;
        static void Main(string[] args)
        {
            //Add debug sample
            Debug.AddDebugSamples();
            //Looping
            bool looping;
            looping = true;
            while(looping == true)
            {
                try
                {
                    ProgramMechanics.UpdateHeader();
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
                            case "--select-task":
                            //TODO: Selects a Financialtask
                                Display.PrintSelectFinancialTask();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--select-plan":
                            //TODO: Selects an plan to this instance
                                Display.PrintSelectFinancialPlan();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--add-tag":
                            //TODO: Adds a tag into the model
                                Display.PrintAddNewTag();
                                Display.PrintTypeAnyKeyToConitinue();
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
                            case "--add-task":
                            //TODO: Adds a Financialtask to this model
                                Display.PrintAddNewFinancialTask();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--add-plan":
                            //TODO: Adds a financial plan to the model
                                Display.PrintAddNewFinancialPlan();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--edit-task":
                            //TODO: Edit Financialtask properties
                                Display.PrintEditFinancialTask();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--edit-wallet":
                            //TODO: Edit wallet
                                Display.PrintEditWallet();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--edit-transaction":
                            //TODO: Edit a transaction
                                Display.PrintEditTransaction();
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
                            case "--display-plans":
                            //TODO: Displays finalcial plans registered in this model
                                Display.PrintFinancialPlans();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--dt-tag":
                            //TODO: Displays tag
                                Display.PrintWalletTransactionsWithTags();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--dt-task":
                                Display.PrintFinancialTasksTransactions();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--dt-plan":
                            //TODO: Display transactions registered on the plan selected only
                                Display.PrintFinancialPlanTransactions();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--dt-plan-u":
                            //TODO: Display transactions registered on the plan selected only with Uri
                                Display.PrintFinancialPlanTransactionsWithUri();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-tasks":
                            //TODO: Displays Financialtasks in the model
                                Display.PrintFinancialTasks();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--display-info":
                            //TODO: Display user info
                                Display.PrintInstanceInfo();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--remove-transaction":
                            //TODO: Removes a transaction from the object selected on the model instance
                                Display.PrintDeleteTransaction();
                                Display.PrintTypeAnyKeyToConitinue();
                            break;
                            case "--exit":
                            //TODO: Reset wallet, Financialtasks in the instance
                                ProgramMechanics.ResetAccount();
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
