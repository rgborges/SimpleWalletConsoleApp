using System;

namespace SimpleWalletConsoleApp.Models
{
    public class Transaction
    {
        public int Id { protected set; get;}
        public double Value { set; get;}
        public string Description { set; get;}
        public Tag Tag { set; get; }
        public Wallet Origin { protected set; get;}
        public Transaction(double value, string description, Wallet wallet)
        {
            this.Value = value;
            this.Description = description;
            this.Origin = wallet;
            this.Id = 0;
        }
        public Transaction(double value, string description, Wallet wallet, Tag tag)
        {
            this.Value = value;
            this.Description = description;
            this.Origin = wallet;
            this.Tag = tag;
            this.Id = 0;
        }
        public Transaction(double value, string description, Wallet wallet, Tag tag, int id)
        {
            this.Value = value;
            this.Description = description;
            this.Origin = wallet;
            this.Tag = tag;
            this.Id = id;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Value: {Value}, Description: {Description}, Origin: {Origin.Owner}";
        }
    }
}