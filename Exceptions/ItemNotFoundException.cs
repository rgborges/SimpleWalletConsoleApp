using System;

namespace SimpleWalletConsoleApp.Exceptions
{
    public class ItemNotFoundException: Exception
    {
        public ItemNotFoundException(string msg = "Item not found") : base(msg)
        {

        }
    }
}