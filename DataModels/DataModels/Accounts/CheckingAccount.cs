using System;

namespace DataModels.Accounts
{
    public class CheckingAccount : BasicAccount
    {
        public CheckingAccount(Guid ownerId, double balance) : base(ownerId, balance) { }
    }
}
