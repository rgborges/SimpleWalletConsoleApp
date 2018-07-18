using System;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Models.Financial;
using SimpleWalletConsoleApp.Models.Function;


namespace SimpleWalletConsoleApp
{
    class ProgramMechanics
    {
        public static void UpdateHeader(string componet)
        {
            Program.Header += @"\" + componet;
        }
        public static void UpdateHeaderWithTask(Task task)
        {
            Program.Header += $"[{task.Name}]";
        }
    }

}