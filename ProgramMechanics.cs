using System;
using System.Globalization;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Models.Financial;
using SimpleWalletConsoleApp.Models.Function;


namespace SimpleWalletConsoleApp
{
    class ProgramMechanics
    {
        public static void ResetAccount()
        {
            //Resets the indexes
            Program.Header = Settings.ApplicationName;
            Program.CurrentWalletIndex = -1;
            Program.CurrentFinancialTaskId = -1;
            Program.CurrentFinancialPlanId = -1;
        }
        public static void UpdateHeader()
        {
            if(BusinessRules.IsWalletSelected())
            {
                string walletName = Program.Wallets[Program.CurrentWalletIndex].Name;
                Program.Header = Settings.ApplicationName + @"\" + $"{walletName}";
                if(BusinessRules.IsFinancialTaskSelected())
                {
                    string FinancialtaskName = Program.FinancialTasks[Program.CurrentFinancialTaskId].Name;
                    double subTotal = Program.FinancialTasks[Program.CurrentFinancialTaskId].GetTotalCost();
                    Program.Header += $"[{FinancialtaskName}, R$ {subTotal.ToString(CultureInfo.InvariantCulture)}]";
                }
                else if(BusinessRules.IsFinancialPlanSelected())
                {
                    string financialPlanName = Program.FinancialPlans[Program.CurrentFinancialPlanId].Title;
                    double subTotal = Program.FinancialPlans[Program.CurrentFinancialPlanId].GetTotalCost();
                    Program.Header += $"[{financialPlanName}, R$ {subTotal.ToString(CultureInfo.InvariantCulture)}]";
                }        
            }
            else
            {
                Program.Header = Settings.ApplicationName;
            }
        }
        public static void ShowInstanceInfo()
        {
            if(BusinessRules.IsUserSelected())
            {
                Display.PrintUserInfo();
            }
            else if(BusinessRules.IsWalletSelected())
            {
                Display.PrintWalletInfo();
            }
            else
            {
                throw new BusinessException("None info to be displayed, plese select an object to the instance.");
            }
        }
        public static void UpdateHeader(string componet)
        {
            Program.Header = Settings.ApplicationName + @"\" + componet;
        }
        public static void UpdateHeaderWithFinancialTask(FinancialTask Financialtask)
        {
            Program.Header = Settings.ApplicationName +  $"[{Financialtask.Name}]";
        }
        public static ConsoleColor GetTagColor(Tag tag)
        {
            ConsoleColor color;
            switch(tag.Color)
            {
                case TagColor.Blue:
                    color = ConsoleColor.Blue;
                break;
                case TagColor.Green:
                    color = ConsoleColor.Green;
                break;
                case TagColor.Red:
                    color = ConsoleColor.Red;
                break;
                case TagColor.Yellow:
                    color = ConsoleColor.Yellow;
                break;
                default:
                    color = ConsoleColor.White;
                break;
            }
            return color;
        }
    }
}