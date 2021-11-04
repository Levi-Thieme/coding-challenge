using DataModels.Accounts;
using System;
using System.Collections.Generic;

namespace DataModels
{
    public class Bank
    {
        public string Name { get; }
        public IEnumerable<IAccount> Accounts { get; private set; }

        public Bank(string name, IEnumerable<IAccount> accounts)
        {
            Name = name;
            Accounts = accounts;
        }
    }
}
