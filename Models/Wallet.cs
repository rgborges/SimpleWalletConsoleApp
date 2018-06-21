using System;
using System.Collections.Generic;

namespace SimpleWalletConsoleApp.Models
{
    public class Wallet
    {
        public int Id { protected set; get;}
        public string Name { set; get;}
        public SystemUser Owner { set; get;}
        private List<Transaction> Transactions = new List<Transaction>();
        public Wallet(string name, SystemUser owner)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = 0;
        }
        public Wallet(string name, SystemUser owner, int id)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = id;
        }
        public Wallet(string name, SystemUser owner, List<Transaction> transactions)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = 0;
            ImportTransactions(transactions);
        }
           public Wallet(string name, SystemUser owner, List<Transaction> transactions, int id)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = id;
            ImportTransactions(transactions);
        }
        public void ImportTransactions(List<Transaction> transactions)
        {
            if(transactions != null)
            {
                Transactions = transactions;
            }
            else
            {
                throw new NullReferenceException("Error: Transactions list reiceived in the Method: ImportTransactions is null");
            }
        }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Name}, Owner: {Owner.FullName}";
        }
    }
}