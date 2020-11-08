using SGBank.Models.Interfaces;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        string path = @".\Accounts.txt";

        public Account LoadAccount(string AccountNumber)
        {

            if(!File.Exists(path))
            {
                var acctFile = File.Create(path);
                acctFile.Close(); // if file not closed before writing, throws error

                using (StreamWriter stream = new StreamWriter(path))
                {
                    stream.WriteLine("AccountNumber,Name,Balance,Type");
                    stream.WriteLine("11111,Free Customer,100,F");
                    stream.WriteLine("22222,Basic Customer,500,B");
                    stream.WriteLine("33333,Premium Customer,1000,P");

                }

            }

            List<Account> accts = new List<Account>();
            string[] rows = File.ReadAllLines(path);

            for(int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Account a = new Account();

                a.AccountNumber = columns[0];
                a.Name = columns[1];
                a.Balance = Convert.ToDecimal(columns[2]);
                
                switch(columns[3])
                {
                    case "F":
                        a.Type = AccountType.Free;
                        break;
                    case "B":
                        a.Type = AccountType.Basic;
                        break;
                    case "P":
                        a.Type = AccountType.Premium;
                        break;
                }

                accts.Add(a);

            }

            if(accts.Exists(x => x.AccountNumber == AccountNumber))
            {
                return accts[accts.FindIndex(x => x.AccountNumber == AccountNumber)];
            }
            else
            {
                return null;
            }


        }

        public void SaveAccount(Account account)
        {
            if (!File.Exists(path))
            {
                var acctFile = File.Create(path);
                acctFile.Close();
                
                using (StreamWriter stream = new StreamWriter(path))
                {
                    stream.WriteLine("AccountNumber,Name,Balance,Type");
                    stream.WriteLine("11111,Free Customer,100,F");
                    stream.WriteLine("22222,Basic Customer,500,B");
                    stream.WriteLine("33333,Premium Customer,1000,P");

                }

            }
            string type = "Default"; // if you see this in the file, bad things are happening

            //convert account type into string for concat
            // if not done and account.Type is thrown in, next lookup of that account will fail
            switch (account.Type) 
            {
                case AccountType.Free:
                    type = "F";
                    break;
                case AccountType.Basic:
                    type = "B";
                    break;
                case AccountType.Premium:
                    type = "P";
                    break;
            }

            string output = account.AccountNumber + "," + account.Name + "," + account.Balance + "," + type;

            string[] rows = File.ReadAllLines(path);

            // iterate through file looking for accountnumber substring
            // if found, replace string in collection and write updated version
            for (int i = 1; i < rows.Length; i++) 
            {
                if(rows[i].Contains(account.AccountNumber))
                {
                    rows[i] = output;
                    File.WriteAllLines(path, rows);
                    
                }
                
            }

        }


    }
}
