using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Models.Financial;


namespace SimpleWalletConsoleApp.Models.Function
{
    public class FinancialPlan
    {
        public Guid Id {private set; get; }
        public string Title {private set; get;}
        public Tag Tag {private set; get;}
        public DateTime RegisterDate {private set; get; }
        private List<Transaction> transactions;
        //Standard constructor
        public FinancialPlan(string title, Tag tag)
        {  
            if(string.IsNullOrEmpty(title))
            {
                throw new BusinessException("Title passaed is null or empity, please write a valid name.");
            }
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.RegisterDate = DateTime.Now;
            this.Tag = tag;
            this.transactions = new List<Transaction>();
        }
        //Adds a transaction to the plan
        public void AddTransaction(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new BusinessException("You're trying to add a null transaction to this plan, please add a valid transaction");
            }
            transactions.Add(transaction);
        }
        //Retuns the total cost
        public double GetTotalCost()
        {
            double sum = 0;
            var query = from item in transactions where item.Type == TransactionType.Spending select item;
            foreach(Transaction p in query)
            {
                sum += p.Value;
            }
            return sum;
        }
        //Returns the total of receives
        public double GetTotalReceives()
        {
            double sum = 0;
            var query = from item in transactions where item.Type == TransactionType.Receive select item;
            foreach(Transaction p in query)
            {
                sum += p.Value;
            }
            return sum;
        }
        //Returns all contained plan transactions
        public List<Transaction> GetTransactions()
        {
            return transactions;
        }
        //Edits the tile name
        public void EditTitle(string title)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            {
                throw new NullReferenceException();
            }
            this.Title = title;
        }
        //Removes a transaction from the plan list
        public void RemoveTransaction(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new BusinessException("You passed a null parameter at FinancialPlan.RemoveTransaction(transaction)");
            }
            transactions.Remove(transaction);
        }
        //Removes a trasaction from the plan list by Guid
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
        //Pass object to string Human like message
        public override string ToString()
        {
            return $"Title: {this.Title}, Date: {this.RegisterDate}, Total Costs: {this.GetTotalCost().ToString("F2", CultureInfo.InvariantCulture)}, Tag: {this.Tag.Name}, Guid: {this.Id}";
        }
    }
}