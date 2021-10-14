using System;
using Profile.Challenges.UnitTesting.Models;
using Xunit;

namespace Profile.Challenges.UnitTesting
{
    public class RecurrenceTests
    {
        /// <summary>
        /// Current test method is provides not full example. Try to find out, what scenarios were missed, and try to fill the gap. You are free to add test methods here.
        /// </summary>
        [Fact]
        public void GenerateEventsTest()
        {
            //Arrange
            var recurrence = new Recurrence(1, Weekday.Monday | Weekday.Friday, new DateTime(2021, 1, 1),
                new DateTime(2021, 1, 14), TimeSpan.FromHours(1));

            //Act 
            //TODO: insert your code here.

            //Assert
            //TODO: insert your code here.
        }
        
        //TODO: Add test methods if any methods are needed.
    }
}