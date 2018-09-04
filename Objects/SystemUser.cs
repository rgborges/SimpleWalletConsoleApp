using System;

namespace SimpleWalletConsoleApp.Objects
{
    public partial class SystemUser : Person
    {
        public string Username { protected set; get;}
        private string Password { set; get; }
        public SystemUser(string fullName, string userName, string password ) : base (fullName)
        {
            this.Username = userName;
            this.Password = password;
        }
        public override string ToString()
        {
            return base.ToString() + $", Username: {Username} ";
        }
    }

}