using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class TransactionStoreTests
    {
        private TransactionStore _transactionStore;
        private IClock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = Substitute.For<IClock>();
            _transactionStore = new TransactionStore(_clock);
        }

        [Test]
        public void VerifyTransactionStoreIsEmptyBeforeTransactionPerformed()
        {
            var transactions = _transactionStore.AllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void VerifyDepositTransactionIsStoredInTransactionStore()
        {
            const int amount = 100;
            var today = new DateTime(2018, 2, 4);

            _clock.UtcNow.Returns(today);

            _transactionStore.Deposit(amount);

            var transactions = _transactionStore.AllTransactions().ToList();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions.First(), Is.EqualTo(new Transaction(amount, today)));
        }

        [Test]
        public void VerifyWithdrawlTransactionIsStoredInTransactionStore()
        {
            const int amount = 100;
            var today = new DateTime(2018, 2, 4);

            _clock.UtcNow.Returns(today);

            _transactionStore.Withdraw(amount);

            var transactions = _transactionStore.AllTransactions().ToList();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions.First(), Is.EqualTo(new Transaction(-amount, today)));
        }
    }
}