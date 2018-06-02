using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class AccountTests
    {
        private Account _account;
        private IStoreTransactions _transactionStore;
        private IPrintStatements _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _transactionStore = Substitute.For<IStoreTransactions>();
            _statementPrinter = Substitute.For<IPrintStatements>();
            _account = new Account(_transactionStore, _statementPrinter);
        }

        [Test]
        public void StoreADepositTransaction()
        {
            const int amount = 1000;

            _account.Deposit(amount);

            _transactionStore.Received().Deposit(amount);
        }

        [Test]
        public void StoreAWithdrawlTransaction()
        {
            const int amount = 1000;

            _account.Withdraw(amount);

            _transactionStore.Received().Withdraw(amount);
        }

        [Test]
        public void PrintAStatement()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(1000, new DateTime(2014, 1, 1)),
                new Transaction(-500, new DateTime(2014, 1, 2)),
                new Transaction(1500, new DateTime(2014, 1, 4))
            };

            var statement = new Statement(transactions);

            _transactionStore.AllTransactions().Returns(transactions);

            _account.PrintStatement();

            _statementPrinter.Received().PrintStatement(statement);
        }
    }
}
