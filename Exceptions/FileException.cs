using System;

namespace SimpleWalletConsoleApp.Exceptions
{
    public class FileException : Exception
    {
        public FileException(string msg) : base (msg)
        {
            
        }
    }
}