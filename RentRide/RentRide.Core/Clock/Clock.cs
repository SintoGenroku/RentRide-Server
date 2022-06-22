using RentRide.Core.Clock.Abstracts;
using System;

namespace RentRide.Core.Clock
{
    public class Clock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}