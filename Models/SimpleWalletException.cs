using System;

namespace SimpleWalletConsoleApp.Models
{
    public class SimpleWalletException : Exception
    {
        public SimpleWalletException(string msg ) : base (msg)
        {

        }
    }
}