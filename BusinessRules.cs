using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Models.Financial;


namespace SimpleWalletConsoleApp
{
    public partial class BusinessRules
    {
        public static void ChecksIfWalletIsSelected()
        {
           if(Program.Wallets[Program.CurrentWalletIndex] == null)
           {
               throw new BusinessException("Business Rules: I doesn't exist a wallet in the actual instance .. please create/select or just select a wallet");
           }
        }
    }
}