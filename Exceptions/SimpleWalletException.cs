using System;

namespace SimpleWalletConsoleApp.Exceptions
{
    public class SimpleWalletException : Exception
    {
        public SimpleWalletException(string msg ) : base (msg)
        {

        }
    }
}