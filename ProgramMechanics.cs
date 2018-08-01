using System;
using System.Globalization;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Models.Financial;
using SimpleWalletConsoleApp.Models.Function;


namespace SimpleWalletConsoleApp
{
    class ProgramMechanics
    {
        public static void ResetAccount()
        {
            Program.Header = Settings.ApplicationName;
            Program.CurrentWalletIndex = -1;
            Program.CurrentTaskId = -1;
        }
        public static void UpdateHeader()
        {
            if(BusinessRules.IsWalletSelected())
            {
                string walletName = Program.Wallets[Program.CurrentWalletIndex].Name;
                Program.Header = Settings.ApplicationName + @"\" + $"{walletName}";
                if(BusinessRules.IsTaskSelected())
                {
                    string taskName = Program.Tasks[Program.CurrentTaskId].Name;
                    double subTotal = Program.Tasks[Program.CurrentTaskId].GetTotalCost();
                    Program.Header += $"[{taskName}, R$ {subTotal.ToString(CultureInfo.InvariantCulture)}]";
                }
            }
            else
            {
                Program.Header = Settings.ApplicationName;
            }
        }
        public static void UpdateHeader(string componet)
        {
            Program.Header = Settings.ApplicationName + @"\" + componet;
        }
        public static void UpdateHeaderWithTask(Task task)
        {
            Program.Header = Settings.ApplicationName +  $"[{task.Name}]";
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