using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Accounts
{
    public class BasicAccount : ITransactional
    {
        public Guid OwnerId { get; private set; }
        public double Balance { get; private set; }

        public BasicAccount(Guid ownerId, double balance)
        {
            OwnerId = ownerId;
            Balance = balance;
        }

        public virtual void Deposit(double amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public virtual void Transfer(double amount, IHandleDeposits transferRecipient)
        {
            Balance -= amount;
            transferRecipient.Deposit(amount);
        }
    }
}
