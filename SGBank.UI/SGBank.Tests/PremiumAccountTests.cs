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
    public class PremiumAccountTests
    {
        [TestCase("33333", "Premium Account", 50, AccountType.Free, 150, false)] // wrong account type
        [TestCase("33333", "Premium Account", 100, AccountType.Premium, -375, false)] // negative number deposit
        [TestCase("33333", "Premium Account", 50, AccountType.Premium, 350, true)] //success
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accounttype, decimal amount, bool expectedResult)
        {
            IDeposit pDepositTest = new NoLimitDepositRule();

            Account accountTest = new Account();
            accountTest.AccountNumber = accountNumber;
            accountTest.Name = name;
            accountTest.Balance = balance;
            accountTest.Type = accounttype;

            AccountDepositResponse pDepTest = pDepositTest.Deposit(accountTest, amount);

            Assert.AreEqual(expectedResult, pDepTest.Success);
        }

        [TestCase("33333", "Premium Account", 450, AccountType.Premium, -1000, -550, false)] // too much withdrawn
        [TestCase("33333", "Premium Account", 100, AccountType.Basic, -100, 100, false)] //not a premium account type
        [TestCase("33333", "Premium Account", 100, AccountType.Premium, 100, 100, false)] // positive number withdrawn
        [TestCase("33333", "Premium Account", 150, AccountType.Premium, -50, 100, true)] //success
        [TestCase("33333", "Basic Account", 100, AccountType.Premium, -250, -150, true)] // success with overdraft
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accounttype, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw pWithdrawTest = new PremiumAccountWithdrawRule();
            Account accountTest = new Account();

            accountTest.AccountNumber = accountNumber;
            accountTest.Name = name;
            accountTest.Balance = balance;
            accountTest.Type = accounttype;

            AccountWithdrawResponse pWithTest = pWithdrawTest.Withdraw(accountTest, amount); ;


            Assert.AreEqual(expectedResult, pWithTest.Success);
            if (pWithTest.Success == true)
                Assert.AreEqual(newBalance, pWithTest.Account.Balance);
        }
    }
}
