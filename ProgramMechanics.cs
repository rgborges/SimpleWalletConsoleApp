using System;
using System.Collections.Generic;

using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Models.Financial;


namespace SimpleWalletConsoleApp
{
    class ProgramMechanics
    {
        public static void UpdateHeader(string componet)
        {
            Program.Header += @"\" + componet;
        }
    }

}