using DataModels.Accounts.Exceptions;
using System;

namespace DataModels.Accounts.InvestmentAccounts
{
    public class IndividualInvestmentAccount : BasicAccount
    {
        public readonly double MAXIMUM_WITHDRAWAL_AMOUNT = 500;

        public IndividualInvestmentAccount(Guid ownerId, double balance) : base(ownerId, balance) { }

        override public void Withdraw(double amount)
        {
            if (amount > MAXIMUM_WITHDRAWAL_AMOUNT)
            {
                throw new InvalidWithdrawalAmountException(amount);
            }
            base.Withdraw(amount);
        }
    }
}
