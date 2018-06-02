using System.Collections.Generic;

namespace BankKata
{
    public interface IStoreTransactions
    {
        void Deposit(int amount);
        void Withdraw(int amount);
        IReadOnlyCollection<Transaction> AllTransactions();
    }
}