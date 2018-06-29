using System;

namespace SimpleWalletConsoleApp.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base (msg)
        {
            
        }
    }
}