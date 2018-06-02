using System;

namespace BankKata
{
    public class DefaultClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}