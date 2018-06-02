namespace BankKata
{
    public class StatementPrinter : IPrintStatements
    {
        private readonly IConsole _console;

        public StatementPrinter(IConsole console)
        {
            _console = console;
        }

        public void PrintStatement(Statement statement)
        {
            _console.PrintLine("DATE | AMOUNT | BALANCE");

            foreach (var statementLine in statement.GetStatementLines())
            {
                _console.PrintLine(statementLine.ToString());
            }
        }
    }
}