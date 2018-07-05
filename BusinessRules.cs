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
               throw new BusinessException("It doesn't exist a wallet in the actual instance .. please create/select or just select a wallet");
           }
        }
        public static void ChecksIfAnUserIsSelected()
        {
            if(Program.Users[Program.CurrentUserIndex] == null)
            {
                throw new BusinessException("No User instance is selected.");
            }
        }
    }
}