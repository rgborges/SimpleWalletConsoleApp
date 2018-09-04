using System;
using System.Linq;
using System.Collections.Generic;
using SimpleWalletConsoleApp.Objects;
using SimpleWalletConsoleApp.Exceptions;

namespace SimpleWalletConsoleApp.Objects.Financial
{
    public class Wallet
    {
        public Guid Id { protected set; get;}
        public string Name { set; get;}
        public SystemUser Owner { set; get;}
        public double Ballance { protected set; get;}
        public DateTime RgeisterDate { protected set; get;}
        public List<Transaction> transactions {protected set; get;}
        public Wallet(string name, SystemUser owner)
        {
            this.Name = name;
            this.Owner = owner;
            this.Id = Guid.NewGuid();
            this.Ballance = 0.0;
            this.RgeisterDate = DateTime.Now;
            transactions = new List<Transaction>();
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
        //Debits a spending type transaction in transactions list and updates the ballance
        public void Debit(Transaction transaction)
        {
            if ( transaction == null)
            {
                throw new NullReferenceException("transactions object passed in Debit method in Wallet.Debit is null");
            }
            transaction.SetAsOutputFlow();
            Ballance -= transaction.Value;
            transactions.Add(transaction);
        }
        //Deposits a receive type transaction in transactions list and updates the ballance
        public void Deposit(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new NullReferenceException("transaction object passed in Deposit method in Wallet.Deposit is null");
            }
            transaction.SetAsInputFlow();
            Ballance += transaction.Value;
            transactions.Add(transaction);
        }
        //Import all transactions - the transactions list will be replaced
        public void ImportTransactions(List<Transaction> transactions)
        {
            if(transactions != null)
            {
                this.transactions = transactions;
            }
            else
            {
                throw new NullReferenceException("transactions list reiceived in the Method: Importtransactions is null");
            }
        }
        //Edits the wallet name
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
        //Redifines the ballance value
        public void EditBallance(double newBallance)
        {
            this.Ballance = newBallance;
        }
        //Edit register date information
        public void EditRegisterDate(DateTime newDate)
        {
            this.RgeisterDate = newDate;
        }
        //Removes a transactions from this wallet by guid
        public void RemoveTransactionById(Guid guid)
        {
             int searchedIndex = transactions.FindIndex( x => x.Id == guid);
            if(searchedIndex == -1)
            {
                throw new ItemNotFoundException("Was not possible to find the transactions in this list.");
            }
            Transaction reference = transactions[searchedIndex];
            transactions.Remove(reference);
        }
        //Returns the number of transactions
        public int GetTransactionsNumber()
        {
            return transactions.Count;
        }
        //Returns the total spending amount
        public double GetTotalSpending()
        {
            double sum = 0;
            var query = from p in transactions where p.Type == TransactionType.Spending orderby p.Date descending select p;
            foreach(var p in query)
            {
                sum += p.Value;
            }
            return sum;
        }
        //Returns the total receive ammount
        public double GetTotalReceives()
        {
            double sum = 0;
            var query = from p in transactions where p.Type == TransactionType.Receive orderby p.Date descending select p;
            foreach(var p in query)
            {
                sum += p.Value;
            }
            return sum;
        }
        //Defines the object string format
        public override string ToString()
        {
            return $"Title: {Name}, Owner: {Owner.FullName}, Id: {Id}";
        }
    }
}