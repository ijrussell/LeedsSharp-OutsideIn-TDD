using System;
using System.Collections.Generic;

namespace BankKata
{
    public class Transaction : IEquatable<Transaction>
    {
        public Transaction(int amount, DateTime createdDate)
        {
            CreatedDate = createdDate;
            Amount = amount;
        }

        public int Amount { get; }
        public DateTime CreatedDate { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Transaction);
        }

        public bool Equals(Transaction other)
        {
            return other != null &&
                   Amount == other.Amount &&
                   CreatedDate == other.CreatedDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 1961644288;
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + CreatedDate.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Transaction transaction1, Transaction transaction2)
        {
            return EqualityComparer<Transaction>.Default.Equals(transaction1, transaction2);
        }

        public static bool operator !=(Transaction transaction1, Transaction transaction2)
        {
            return !(transaction1 == transaction2);
        }
    }
}