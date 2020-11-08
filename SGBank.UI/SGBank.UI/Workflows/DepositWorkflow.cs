using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            decimal amount;

            Console.Write("Enter a deposit amount: ");
            while(!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Not a valid deposit amount.");
                Console.Write("Enter a deposit amount: ");
            }

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if(response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: ${response.oldBalance.ToString("0.00")}");
                Console.WriteLine($"Amount Deposited: {response.Amount:c}");
                Console.WriteLine($"New Balance: ${response.Account.Balance.ToString("0.00")}");
            }
            else
            {
                Console.WriteLine("An error ocurred: ");
                Console.WriteLine(response.Message);

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
