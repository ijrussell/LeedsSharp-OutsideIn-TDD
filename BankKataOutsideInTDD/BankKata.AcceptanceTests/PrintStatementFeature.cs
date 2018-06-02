using System;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.AcceptanceTests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private IConsole _console;
        private IStoreTransactions _transactionStore;
        private IPrintStatements _statementPrinter;
        private IClock _clock;
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _clock = Substitute.For<IClock>();
            _transactionStore = new TransactionStore(_clock);
            _statementPrinter = new StatementPrinter(_console);

            _account = new Account(_transactionStore, _statementPrinter);
        }

        [Test]
        public void PrintStatementContainingAllTransactions()
        {
            _clock.UtcNow.Returns(new DateTime(2018, 4, 1), new DateTime(2018, 4, 2), new DateTime(2018, 4, 4));

            _account.Deposit(1000);
            _account.Withdraw(100);
            _account.Deposit(500);

            _account.PrintStatement();

            Received.InOrder(() => {
                _console.PrintLine("DATE | AMOUNT | BALANCE");
                _console.PrintLine("04/04/2018 | 500 | 1400");
                _console.PrintLine("02/04/2018 | -100 | 900");
                _console.PrintLine("01/04/2018 | 1000 | 1000");
            });
        }
    }
}
