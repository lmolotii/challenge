using System;

namespace Profile.Challenges.UnitTesting.Models
{
    [Flags]
    public enum Weekday : byte
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4, 
        Wednesday = 8, 
        Thursday = 16, 
        Friday = 32, 
        Saturday = 64
    }
}