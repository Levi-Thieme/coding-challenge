using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Accounts
{
    public interface ITransactional : IHandleDeposits, IHandleWithdrawals, IHandleTransfers { }

    public interface IHandleDeposits
    {
        void Deposit(double amount);
    }

    public interface IHandleWithdrawals
    {
        void Withdraw(double amount);
    }

    public interface IHandleTransfers
    {
        void Transfer(double amount, IHandleDeposits transferRecipient);
    }
}
