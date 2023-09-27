using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int s_accountNumberSeed = 12345678;

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;

            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        private List<Transaction> _allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount));
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("not sufficient funds for this withdrawl");
            }
            var withdrawl = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawl);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToString()}\t{transaction.Amount}\t{transaction.Notes}");
            }

            return report.ToString();
        }
    }
}
