using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWalletConsoleApp.Objects;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Objects.Financial;


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
        public static void ChecksIfAFinancialTaskIsSelected()
        {
            if(Program.CurrentFinancialTaskId == -1)
            {
                throw new BusinessException("It doesn't exist a Financialtask selected in this instance ... please select a Financialtask in the instance");
            }
        }
        public static void ChecksIfFinancialPlanIsSelected()
        {
            if(Program.CurrentFinancialPlanId == -1)
            {
                throw new BusinessException("It doesn't exist a plan selected in this instance ... please select a Financial plan in the instance");
            }   
        }
        public static bool IsUserSelected()
        {
            if(Program.CurrentUserIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
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
        public static bool IsFinancialTaskSelected()
        {
            if(Program.CurrentFinancialTaskId >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsFinancialPlanSelected()
        {
            if(Program.CurrentFinancialPlanId >= 0)
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