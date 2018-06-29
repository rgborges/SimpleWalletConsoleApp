using System;

namespace SimpleWalletConsoleApp.Models.Financial
{
    public abstract class FinancialHolder
    {
        private double Ballance { set; get;}
        private void Debit (double value )
        {
            Ballance -= value;
        }
        private void Deposit(double value)
        {
            Ballance += value;
        }
    }
}