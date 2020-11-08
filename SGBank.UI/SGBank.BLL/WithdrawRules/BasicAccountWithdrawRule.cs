using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse  response = new AccountWithdrawResponse();

            if(account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: A non-basic account hit the basic withdraw rule. Contact IT.";
                return response;
            }

            if(amount >= 0M)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative!";
                return response;
            }

            if(amount < -500M)
            {
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500.";
                return response;
            }

            if(account.Balance + amount < -100M)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit!";
                return response;
            }

            response.oldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            if (account.Balance < 0)
                account.Balance += -10M; // deduct 10 dollar overdraft

            return response;

        }
        

    }
}
