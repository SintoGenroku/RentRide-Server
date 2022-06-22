using System;

namespace RentRide.Core.Clock.Abstracts
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}