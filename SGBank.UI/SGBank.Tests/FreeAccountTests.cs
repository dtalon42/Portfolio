using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)] // too much deposited
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)] //negative number deposited
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)] //not correct account type
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)] //success
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accounttype, decimal amount, bool expectedResult)
        {
            IDeposit depositTest = new FreeAccountDepositRule();
            Account accountTest = new Account();
            accountTest.AccountNumber = accountNumber;
            accountTest.Name = name;
            accountTest.Balance = balance;
            accountTest.Type = accounttype;

            AccountDepositResponse depTest = depositTest.Deposit(accountTest, amount);

            Assert.AreEqual(expectedResult, depTest.Success);

        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 25, false)] // positive withdrawal amount
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)] //negative withdrawal over limit
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -25, false)] //not correct account type
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)] //success
        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accounttype, decimal amount, bool expectedResult)
        {
            IWithdraw withdrawTest = new FreeAccountWithdrawRules();
            Account accountTest = new Account();
            accountTest.AccountNumber = accountNumber;
            accountTest.Name = name;
            accountTest.Balance = balance;
            accountTest.Type = accounttype;

            AccountWithdrawResponse withTest = withdrawTest.Withdraw(accountTest, amount);

            Assert.AreEqual(expectedResult, withTest.Success);

        }
    }
}
