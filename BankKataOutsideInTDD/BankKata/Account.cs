namespace BankKata
{
    public class Account
    {
        private readonly IStoreTransactions _transactionStore;
        private readonly IPrintStatements _statementPrinter;

        public Account(IStoreTransactions transactionStore, IPrintStatements statementPrinter)
        {
            _transactionStore = transactionStore;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionStore.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionStore.Withdraw(amount);
        }

        public void PrintStatement()
        {
            _statementPrinter.PrintStatement(new Statement(_transactionStore.AllTransactions()));
        }
    }
}