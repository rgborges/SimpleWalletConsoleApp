using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using SimpleWalletConsoleApp.Objects;
using SimpleWalletConsoleApp.Exceptions;
using SimpleWalletConsoleApp.Objects.Financial;


namespace SimpleWalletConsoleApp.Objects.Function
{
    public class FinancialTask
    {
        public Guid Id { private set; get;}
        public string Name { set; get;}
        public Tag Tag { private set; get; }
        public List<Transaction> Transactions { set; get; }
        public DateTime RegisterDate { private set; get;}
        public double Budget { protected set; get; }
        public FinancialTask(string name, TagColor color)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Tag = new Tag(Name, color);
            this.Transactions = new List<Transaction>();
            this.RegisterDate = DateTime.Now;
        }
        public FinancialTask(string name, double budget, TagColor color)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Tag = new Tag(Name, color);
            this.Transactions = new List<Transaction>();
            this.RegisterDate = DateTime.Now;
            this.Budget = budget;
        }
        //Returns the total amount of sepending
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
        //Retuns the total ammount of receives
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
        //Edits the name of this task
        public void EditName(string name)
        {
            this.Name = name;
        }
        //Edits register date property
        public void EditRegisterDate(DateTime date)
        {
            this.RegisterDate = date;
        }
        //Removes a transaction form this task by Id
        public void RemoveTransactionById(Guid guid)
        {
            Transaction transactionSearched = Transactions.Find( x => x.Id == guid);
            if(transactionSearched == null)
            {
                throw new ItemNotFoundException();
            }
            Transactions.Remove(transactionSearched);
        }
        public override string ToString()
        {
            return $"Name: {Name}, Tag {Tag.Name} Total Cost: R$ {GetTotalCost().ToString(CultureInfo.InvariantCulture)},  Budget: R$ {Budget.ToString("F2", CultureInfo.InvariantCulture)}, Guid: {Id}, Register Date {RegisterDate}";
        }
    }
}