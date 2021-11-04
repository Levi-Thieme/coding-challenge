using System;

namespace DataModels.Accounts.InvestmentAccounts
{
    public class CorporateInvestmentAccount : BasicAccount
    {
        public CorporateInvestmentAccount(Guid ownerId, double balance) : base(ownerId, balance) { }
    }
}
