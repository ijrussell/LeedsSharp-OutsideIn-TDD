using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class Statement : IEquatable<Statement>
    {
        private readonly IEnumerable<Transaction> _transactions;

        public Statement(IEnumerable<Transaction> transactions)
        {
            _transactions = transactions;
        }

        public IReadOnlyCollection<StatementLine> GetStatementLines()
        {
            var balance = 0;
            var statementLines = _transactions.Select(x => new StatementLine(x.CreatedDate, x.Amount, balance += x.Amount))
                .ToList();
            statementLines.Reverse();
            return statementLines.AsReadOnly();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Statement);
        }

        public bool Equals(Statement other)
        {
            return other != null &&
                   EqualityComparer<IEnumerable<Transaction>>.Default.Equals(_transactions, other._transactions);
        }

        public override int GetHashCode()
        {
            return -1272138109 + EqualityComparer<IEnumerable<Transaction>>.Default.GetHashCode(_transactions);
        }

        public static bool operator ==(Statement statement1, Statement statement2)
        {
            return EqualityComparer<Statement>.Default.Equals(statement1, statement2);
        }

        public static bool operator !=(Statement statement1, Statement statement2)
        {
            return !(statement1 == statement2);
        }
    }
}