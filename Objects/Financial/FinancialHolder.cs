using System;

namespace SimpleWalletConsoleApp.Objects.Financial
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