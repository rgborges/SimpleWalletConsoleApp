using System;

namespace SimpleWalletConsoleApp.Exceptions
{
    public class InvalidOptionException : Exception
    {
        public InvalidOptionException (string message = "Invalid option was used.") : base (message)
        {

        }
    }
}