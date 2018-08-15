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
        private Tag defaultTag = new Tag("unknow", TagColor.Blue);
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
        public void AddTransaction(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new BusinessException("You're trying to add a null transaction to this plan, please add a valid transaction");
            }
            transactions.Add(transaction);
        }
        public void RemoveTransaction(Transaction transaction)
        {
            if(transaction == null)
            {
                throw new BusinessException("You passed a null parameter at FinancialPlan.RemoveTransaction(transaction)");
            }
            transactions.Remove(transaction);
        }
        public override string ToString()
        {
            return $"Title: {this.Title}, Date: {this.RegisterDate}, Tag: {this.Tag.Name}, Guid: {this.Id}";
        }
    }
}