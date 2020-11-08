using SGBank.Models.Interfaces;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if(account.Type != AccountType.Basic && account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: Only basic and premium accounts can deposit with no limit";
                return response;
            }

            if(amount <= 0M)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be positive!";
                return response;
            }

            response.Success = true;
            response.Account = account;
            response.oldBalance = account.Balance;
            response.Amount = amount;
            account.Balance += amount;
            
            return response;

        }
        
        

        

    }
}
