using FluentAssertions;
using Profile.Challenges.UnitTesting.Logic;
using Profile.Challenges.UnitTesting.Models;
using Xunit;

namespace Profile.Challenges.UnitTesting
{
    public class WeekDayExtensionsTests
    {
        /// <summary>
        /// Current test method is provides as an example. 
        /// </summary>
        [Fact]
        public void GenerateDaysOfWeekTest()
        {
            //Arrange
            var weekDay = Weekday.Monday | Weekday.Tuesday | Weekday.Wednesday;

            //Act 
            var days = weekDay.ToDaysOfWeek();

            //Assert
            days.Count.Should().Be(3);
        }
        
        // TODO: Try to find out, what scenarios were missed, and try to fill the gap. You are free to add test methods here.
    }
}