using System.Collections.Generic;

namespace BankKata
{
    public class TransactionStore : IStoreTransactions
    {
        private readonly IClock _clock;
        private readonly List<Transaction> _transactions;

        public TransactionStore(IClock clock)
        {
            _clock = clock;
            _transactions = new List<Transaction>();
        }

        public void Deposit(int amount)
        {
            _transactions.Add(new Transaction(amount, _clock.UtcNow));
        }

        public void Withdraw(int amount)
        {
            _transactions.Add(new Transaction(-amount, _clock.UtcNow));
        }

        public IReadOnlyCollection<Transaction> AllTransactions()
        {
            return _transactions;
        }
    }
}