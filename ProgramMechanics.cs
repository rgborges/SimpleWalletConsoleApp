using System;
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
        public static void UpdateHeader(string componet)
        {
            Program.Header = Settings.ApplicationName + @"\" + componet;
        }
        public static void UpdateHeaderWithTask(Task task)
        {
            Program.Header = Settings.ApplicationName +  $"[{task.Name}]";
        }
    }

}