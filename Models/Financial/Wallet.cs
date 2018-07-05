using System;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;

namespace SimpleWalletConsoleApp.Models.Financial
{
    public class Wallet
    {
        public Guid Id { protected set; get;}
        public string Name { set; get;}
        public SystemUser Owner { set; get;}
        public double Ballance { protected set; get;}
        private List<Transaction> Transactions = new List<Transaction>();
        public Wallet(string name, SystemUser owner)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = Guid.NewGuid();
            this.Ballance = 0.0;
        }
        public Wallet(string name, SystemUser owner, List<Transaction> transactions)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = Guid.NewGuid();
            this.Ballance = 0.0;
            ImportTransactions(transactions);
        }
        public void Debit(Transaction transaction)
        {
            if ( transaction == null)
            {
                throw new NullReferenceException("transactions object passed in Debit method in Wallet.Debit is null");
            }
            Ballance -= transaction.Value;
            Transactions.Add(transaction);
        }
        public void Deposit(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new NullReferenceException("transaction object passed in Deposit method in Wallet.Deposit is null");
            }
            Ballance += transaction.Value;
            Transactions.Add(transaction);
        }
        public void ImportTransactions(List<Transaction> transactions)
        {
            if(transactions != null)
            {
                Transactions = transactions;
            }
            else
            {
                throw new NullReferenceException("Transactions list reiceived in the Method: ImportTransactions is null");
            }
        }
        public override string ToString()
        {
            return $"Title: {Name}, Owner: {Owner.FullName}, Id: {Id}";
        }
    }
}