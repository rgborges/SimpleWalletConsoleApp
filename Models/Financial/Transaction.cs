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
        public Wallet Origin { protected set; get;}
        public Transaction(double value, string description, Wallet wallet)
        {
            this.Value = value;
            this.Description = description;
            this.Origin = wallet;
            this.Id = Guid.NewGuid();
        }
        public Transaction(double value, string description, Wallet wallet, Tag tag)
        {
            this.Value = value;
            this.Description = description;
            this.Origin = wallet;
            this.Tag = tag;
            this.Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"Id: {Id}, Value: {Value.ToString(CultureInfo.InvariantCulture)} R$, Description: {Description}, Origin: {Origin.Owner}";
        }
    }
}