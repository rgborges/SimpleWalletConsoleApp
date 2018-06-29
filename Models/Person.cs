using System;

namespace SimpleWalletConsoleApp.Models
{
    public partial class Person
    {
        public Guid Id { protected set; get;}
        public string FullName { set; get;}
        public Person(string fullName)
        {
            this.FullName = fullName;
            this.Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"Full Name: {FullName}, Id: {Id}";
        }
    }
}