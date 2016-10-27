using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYear.Tests
{
    using Shouldly;
    using Xunit;

    public class LeapYearCalculatorTests
    {
        private readonly LeapYearCalculator _leapYearCalculator;

        public LeapYearCalculatorTests()
        {
            _leapYearCalculator = new LeapYearCalculator();
        }

        [Fact]
        public void IsLeapYear_100_ReturnFalse()
        {
            //arrange
            var year = 100;

            //act
            var isLeapYear = _leapYearCalculator.IsLeapYear(year);

            //assert
            isLeapYear.ShouldBeFalse();
        }

        [Fact]
        public void IsLeapYear_400_ReturnTrue()
        {
            //arrange
            var year = 400;

            //act
            var isLeapYear = _leapYearCalculator.IsLeapYear(year);

            //assert
            isLeapYear.ShouldBeTrue();
        }

        [Fact]
        public void IsLeapYear_4_ReturnTrue()
        {
            //arrange
            var year = 4;

            //act
            var isLeapYear = _leapYearCalculator.IsLeapYear(year);

            //assert
            isLeapYear.ShouldBeTrue();
        }

        [Fact]
        public void IsLeapYear_2016_ReturnTrue()
        {
            //arrange
            var year = 2016;

            //act
            var isLeapYear = _leapYearCalculator.IsLeapYear(year);

            //assert
            isLeapYear.ShouldBeTrue();
        }

        [Theory]
        [InlineData(400)]
        [InlineData(4)]
        [InlineData(2000)]
        [InlineData(2016)]
        public void IsLeapYear_ReturnTrue(int year)
        {
            //act
            var isLeapYear = _leapYearCalculator.IsLeapYear(year);

            //assert
            isLeapYear.ShouldBeTrue();
        }

        [Theory]
        [InlineData(100)]
        public void IsLeapYear_ReturnFalse(int year)
        {
            //act
            var isLeapYear = _leapYearCalculator.IsLeapYear(year);

            //assert
            isLeapYear.ShouldBeFalse();
        }
    }

    public class LeapYearCalculator
    {
        public bool IsLeapYear(int jahr)
        {
            if (jahr % 400 == 0)
                return true;

            if (jahr % 100 == 0)
                return false;

            if (jahr % 4 == 0)
                return true;

            return false;
            //return (jahr % 4 == 0 && jahr % 100 != 0) || (jahr % 400 == 0);
        }
    }
}
