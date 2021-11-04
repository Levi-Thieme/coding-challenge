using DataModels;
using DataModels.Accounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TheBank
    {
        [TestMethod]
        public void HasAName()
        {
            string expectedName = "Chase";
            var bank = new Bank(expectedName, new List<IAccount>());

            Assert.AreEqual(expectedName, bank.Name);
        }

        [TestMethod]
        public void HasAccounts()
        {
            var accounts = new List<IAccount>();

            var bank = new Bank("Wells Fargo", accounts);

            CollectionAssert.AreEquivalent(accounts, bank.Accounts.ToList());
        }
    }
}
