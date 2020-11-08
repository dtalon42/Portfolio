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
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)] // wrong account type
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)] // negative number deposit
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)] //success
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accounttype, decimal amount, bool expectedResult)
        {
            IDeposit bDepositTest = new NoLimitDepositRule();
            Account accountTest = new Account();
            accountTest.AccountNumber = accountNumber;
            accountTest.Name = name;
            accountTest.Balance = balance;
            accountTest.Type = accounttype;

            AccountDepositResponse bDepTest = bDepositTest.Deposit(accountTest, amount);

            Assert.AreEqual(expectedResult, bDepTest.Success);
        }
        [TestCase("33333","Basic Account", 1500, AccountType.Basic, -1000, 1500, false)] // too much withdrawn
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)] //not a basic account type
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)] // positive number withdrawn
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)] //success
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)] // success with overdraft
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accounttype, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw bWithdrawTest = new BasicAccountWithdrawRule();
            Account accountTest = new Account();
            
            accountTest.AccountNumber = accountNumber;
            accountTest.Name = name;
            accountTest.Balance = balance;
            accountTest.Type = accounttype;

            AccountWithdrawResponse bWithTest = bWithdrawTest.Withdraw(accountTest, amount); ;
            

            Assert.AreEqual(expectedResult, bWithTest.Success);
            if (bWithTest.Success == true)
                Assert.AreEqual(newBalance, bWithTest.Account.Balance);
        }

    }
}
