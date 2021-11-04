using DataModels.Accounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TheBasicAccount
    {
        private BasicAccount account;
        private readonly Guid ownerId = Guid.Parse("304d3ec2-ac4a-4827-b790-a8db2804c027");
        private const double initialBalance = 250;

        [TestInitialize]
        public void InitializeAccount()
        {
            this.account = new BasicAccount(ownerId, initialBalance);
        }

        [TestMethod]
        public void HasAnOwner()
        {
            Assert.AreEqual(ownerId, account.OwnerId);
        }

        [TestMethod]
        public void HasABalance()
        {
            Assert.AreEqual(initialBalance, account.Balance);
        }

        [TestMethod]
        public void SupportsDeposits()
        {
            double expectedBalance = initialBalance * 2;

            account.Deposit(initialBalance);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod]
        public void WhenMakingAWithdrawal_ItReducesTheBalanceByTheAmountWithdrawn()
        {
            double amountToWithdraw = 50;
            double expectedBalance = initialBalance - amountToWithdraw;

            account.Withdraw(amountToWithdraw);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestClass]
        public class WhenMakingATransfer
        {
            private BasicAccount sourceAccount;
            private BasicAccount destinationAccount;
            private readonly Guid sourceAccountId = Guid.Parse("304d3ec2-ac4a-4827-b790-a8db2804c027");
            private readonly Guid destinationAccountId = Guid.Parse("304d3ec2-ac4a-4827-b790-a8db2804c000");
            private const double initialBalance = 250;
            private Mock<IHandleDeposits> mockAccount;

            [TestInitialize]
            public void Initialize()
            {
                sourceAccount = new BasicAccount(sourceAccountId, initialBalance);
                destinationAccount = new BasicAccount(destinationAccountId, initialBalance);
                mockAccount = new Mock<IHandleDeposits>();
            }

            [TestMethod]
            public void TheSourceAccountHasItsBalanceReducedByTheTransferAmount()
            {
                double transferAmount = 50;
                double expectedBalance = sourceAccount.Balance - 50;

                sourceAccount.Transfer(transferAmount, destinationAccount);

                Assert.AreEqual(expectedBalance, sourceAccount.Balance);
            }

            [TestMethod]
            public void TheTransferRecipientHasTheTransferAmountDeposited()
            {
                double transferAmount = 50;
                double expectedBalance = destinationAccount.Balance + 50;

                sourceAccount.Transfer(transferAmount, mockAccount.Object);

                this.mockAccount.Verify(account => account.Deposit(transferAmount), Times.Once);
            }
        }
        
    }
}
