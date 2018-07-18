using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using SimpleWalletConsoleApp.Models;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Models.Financial;


namespace SimpleWalletConsoleApp.Models.Function
{
    public class Task
    {
        public Guid Id { private set; get;}
        public string Name { set; get;}
        public Tag Tag { private set; get; }
        public List<Transaction> Transactions { set; get; }
        public DateTime RegisterDate { private set; get;}
        public Task(string name, TagColor color)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Tag = new Tag(Name, color);
            this.Transactions = new List<Transaction>();
            this.RegisterDate = DateTime.Now;
        }
        public double GetTotalCost()
        {
            double sum = 0;
            var Query = from Transaction in Transactions where (Transaction.Type == TransactionType.Spending) select Transaction;
            foreach(Transaction p in Query)
            {
                sum += p.Value;
            }
            return sum;
        }
        public double GetTotalReceives()
        {
            double sum = 0;
            var Query = from Transaction in Transactions where (Transaction.Type == TransactionType.Receive) select Transaction;
            foreach(Transaction p in Query)
            {
                sum += p.Value;
            }
            return sum;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Tag {Tag} Total Cost: R$ {GetTotalCost().ToString(CultureInfo.InvariantCulture)},  Guid: {Id}, Register Date {RegisterDate}";
        }
    }
}