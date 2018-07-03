using System;

namespace SimpleWalletConsoleApp.Models
{
    public partial class Person
    {
        public Guid Id { protected set; get;}
        public string FullName { set; get;}
        public string Occupation { set; get;}
        public double Salary { set; get;}
        public bool ThirteenthSalary { set; get;}
        public Person(string fullName)
        {
            this.FullName = fullName;
            this.ThirteenthSalary = false;
            this.Id = Guid.NewGuid();
        }
        public Person(string fullName, string occupation, double salary)
        {
            this.FullName = fullName;
            this.ThirteenthSalary = false;
            this.Id = Guid.NewGuid();
            this.Occupation = occupation;
            this.Salary = salary;
        }
        public double GetAnnualSalary()
        {
            //TODO: Returns the annual sallary
            if(ThirteenthSalary) return Salary * 13;
            else 
            {
                return Salary * 12;
            }
        }
        public override string ToString()
        {
            return $"Full Name: {FullName}, Id: {Id}";
        }
    }
}