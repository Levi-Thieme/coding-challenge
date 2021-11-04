using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Accounts.Exceptions
{
    public class InvalidWithdrawalAmountException : Exception
    {
        public double RequestedWithdrawalAmount { get; private set; }

        public InvalidWithdrawalAmountException(double requestedAmount)
        {
            RequestedWithdrawalAmount = requestedAmount;
        }
    }
}
