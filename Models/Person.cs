using System;

namespace SimpleWalletConsoleApp.Models
{
    public partial class Person
    {
        public int Id { protected set; get;}
        public string FullName { set; get;}
        public Person(string fullName)
        {
            this.FullName = fullName;
            this.Id = 0;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Full Name: {FullName}";
        }
    }
}