using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class StatementPrinterTests
    {
        private IConsole _console;
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _statementPrinter = new StatementPrinter(_console);
        }

        [Test]
        public void VerifyStatementWithNoTransactionsOnlyPrintsHeaderRow()
        {
            _statementPrinter.PrintStatement(new Statement(new List<Transaction>()));

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
            _console.Received(1).PrintLine(Arg.Any<string>());
        }

        [Test]
        public void PrintDeposit()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(500, new DateTime(2015, 3, 8))
            };

            _statementPrinter.PrintStatement(new Statement(transactions));

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
            _console.Received().PrintLine("08/03/2015 | 500 | 500");
            _console.Received(2).PrintLine(Arg.Any<string>());
        }

        [Test]
        public void PrintWithdrawl()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(-500, new DateTime(2015, 3, 8))
            };

            _statementPrinter.PrintStatement(new Statement(transactions));

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
            _console.Received().PrintLine("08/03/2015 | -500 | -500");
            _console.Received(2).PrintLine(Arg.Any<string>());
        }

        [Test]
        public void PrintTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(1000, new DateTime(2015, 3, 8)),
                new Transaction(-500, new DateTime(2015, 3, 9)),
                new Transaction(1500, new DateTime(2015, 3, 10))
            };

            _statementPrinter.PrintStatement(new Statement(transactions));

            Received.InOrder(() =>
            {
                _console.PrintLine("DATE | AMOUNT | BALANCE");
                _console.PrintLine("10/03/2015 | 1500 | 2000");
                _console.PrintLine("09/03/2015 | -500 | 500");
                _console.PrintLine("08/03/2015 | 1000 | 1000");
            });
            _console.Received(4).PrintLine(Arg.Any<string>());
        }
    }
}