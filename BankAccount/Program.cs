using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Jon", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

            account.MakeWithdrawl(500, DateTime.Now, "Rent");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(500, DateTime.Now, "Paycheck");
            Console.WriteLine(account.Balance);

            try
            {
                account.MakeWithdrawl(2000, DateTime.Now, "overDrawl");
            }
            catch (Exception ex)
            {
                Console.WriteLine("overdrawl fees will be applied");
                Console.WriteLine(ex.ToString());
            }

            try
            {
                var invalidAccount = new BankAccount("jeff", -100);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception trying to create account with negitive ballence");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(account.GetAccountHistory());

            Console.ReadLine();
        }
    }
}
