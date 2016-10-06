using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace LeapYear.Tests
{
    public class LeapYearTests
    {
        [Fact]
        public void Check_Year1900_IsNoLeapYear()
        {
            //arrange
            var leapYearChecker = new LeapYearChecker();

            //act
            var isLeapYear = leapYearChecker.Check(1900);

            //assert
            isLeapYear.ShouldBeFalse();
        }

        [Fact]
        public void The_year_2000_should_be_a_leap_year()
        {
            //arrange
            var leapYearChecker = new LeapYearChecker();
            
            //act
            var isLeapYear = leapYearChecker.Check(2000);
            
            //assert
            isLeapYear.ShouldBeTrue();
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(2400)]
        public void LeapYearsShouldBeCorrectlyIdentified(int year)
        {
            //arrange
            var leapYearChecker = new LeapYearChecker();

            //act
            var isLeapYear = leapYearChecker.Check(year);

            //assert
            isLeapYear.ShouldBeTrue();
        }

        [Theory]
        [InlineData(1990)]
        [InlineData(2300)]
        public void NonLeapYearsShouldBeCorrectlyIdentified(int year)
        {
            //arrange
            var leapYearChecker = new LeapYearChecker();

            //act
            var isLeapYear = leapYearChecker.Check(year);

            //assert
            isLeapYear.ShouldBeFalse();
        }
    }
}
