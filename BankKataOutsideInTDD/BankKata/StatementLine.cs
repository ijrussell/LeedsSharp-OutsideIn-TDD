using System;

namespace BankKata
{
    public class StatementLine
    {
        public DateTime CreatedDate { get; }
        public int Amount { get; }
        public int Balance { get; }

        public StatementLine(DateTime createdDate, int amount, int balance)
        {
            CreatedDate = createdDate;
            Amount = amount;
            Balance = balance;
        }

        public override string ToString()
        {
            return CreatedDate.ToShortDateString() + " | " + Amount + " | " + Balance;
        }
    }
}