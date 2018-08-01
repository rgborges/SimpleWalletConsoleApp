using System;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;

namespace SimpleWalletConsoleApp.Models.Financial
{
    public class Wallet
    {
        public Guid Id { protected set; get;}
        public string Name { set; get;}
        public SystemUser Owner { set; get;}
        public double Ballance { protected set; get;}
        public DateTime RgeisterDate { protected set; get;}
        public List<Transaction> Transactions {protected set; get;}
        public Wallet(string name, SystemUser owner)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = Guid.NewGuid();
            this.Ballance = 0.0;
            this.RgeisterDate = DateTime.Now;
            Transactions = new List<Transaction>();
        }
        public Wallet(string name, SystemUser owner, List<Transaction> transactions)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = Guid.NewGuid();
            this.Ballance = 0.0;
            this.RgeisterDate = DateTime.Now;
            ImportTransactions(transactions);
        }
        public void Debit(Transaction transaction)
        {
            if ( transaction == null)
            {
                throw new NullReferenceException("transactions object passed in Debit method in Wallet.Debit is null");
            }
            transaction.SetAsOutputFlow();
            Ballance -= transaction.Value;
            Transactions.Add(transaction);
        }
        public void Deposit(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new NullReferenceException("transaction object passed in Deposit method in Wallet.Deposit is null");
            }
            transaction.SetAsInputFlow();
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
        public void EditName(string newName)
        {
            if(!String.IsNullOrEmpty(newName))
            {
                this.Name = newName;
            }
            else
            {
                throw new BusinessException("The name inserted is empity or null");
            }
        }
        public void EditBallance(double newBallance)
        {
            this.Ballance = newBallance;
        }
        public void EditRegisterDate(DateTime newDate)
        {
            this.RgeisterDate = newDate;
        }
        public override string ToString()
        {
            return $"Title: {Name}, Owner: {Owner.FullName}, Id: {Id}";
        }
    }
}