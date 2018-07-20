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
           if(Program.CurrentWalletIndex == -1)
           {
               throw new BusinessException("It doesn't exist a wallet in the actual instance .. please create/select or just select a wallet");
           }
        }
        public static void ChecksIfAnUserIsSelected()
        {
            if(Program.CurrentUserIndex == -1)
            {
                throw new BusinessException("No User instance is selected.");
            }
        }
        public static void ChecksIfATaskIsSelected()
        {
            if(Program.CurrentTaskId == -1)
            {
                throw new BusinessException("No task is selected in this model instance");
            }
        }
        public static bool IsWalletSelected()
        {
            if(Program.CurrentWalletIndex >= 0)
           {
               return true;
           }
           else
           {
               return false;
           }
        }
        public static bool IsTaskSelected()
        {
            if(Program.CurrentTaskId >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}