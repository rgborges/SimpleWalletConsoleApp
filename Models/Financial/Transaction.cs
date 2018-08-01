using System;
using System.Globalization;
using SimpleWalletConsoleApp.Models;

namespace SimpleWalletConsoleApp.Models.Financial
{
    public class Transaction
    {
        public Guid Id { protected set; get;}
        public double Value { set; get;}
        public string Description { set; get;}
        public Tag Tag { set; get; }
        public TransactionType Type {protected set; get;}
        public Wallet Origin { protected set; get;}
        public DateTime Date { protected set; get;}
        public CashFlow Flow { protected set; get; }
        public Transaction(double value, string description,TransactionType type, Wallet wallet)
        {
            this.Value = value;
            this.Description = description;
            this.Type = type;
            this.Origin = wallet;
            this.Id = Guid.NewGuid();
            this.Date = DateTime.Now;
            this.Flow = CashFlow.Invalid;
        }
        public Transaction(double value, string description,TransactionType type, Wallet wallet, Tag tag)
        {
            this.Value = value;
            this.Description = description;
            this.Origin = wallet;
            this.Type = type;
            this.Tag = tag;
            this.Id = Guid.NewGuid();
            this.Date = DateTime.Now;
            this.Flow = CashFlow.Invalid;
        }
        public void  SetAsOutputFlow()
        {
            Flow = CashFlow.Output;
        }
        public void  SetAsInputFlow()
        {
            Flow = CashFlow.Input;
        }
        public override string ToString()
        {
            string result =  null;
            switch (Type)
            {
                case TransactionType.Receive:
                    result = $" + Value: R$ {Value.ToString("F2",CultureInfo.InvariantCulture)}, Date: {Date}, Description: {Description}, Guid: {Id} ";
                break;
                case TransactionType.Spending:
                    result = $" - Value: R$ {Value.ToString("F2",CultureInfo.InvariantCulture)}, Date: {Date}, Description: {Description}, Guid: {Id} ";
                break;
                case (TransactionType.Transfering):
                    result = $" <-> Value: R$ {Value.ToString("F2",CultureInfo.InvariantCulture)}, Date: {Date}, Description: {Description}, Guid: {Id} ";
                break;
                default:
                    result = $" ? Value: R$ {Value.ToString("F2",CultureInfo.InvariantCulture)}, Date: {Date}, Description: {Description}, Guid: {Id} ";
                break;
            }
            return result;
        }
    }
}