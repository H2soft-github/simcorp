using SimcorpPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpTestsUnit
{
    public class ArgsToDecimalsTests
    {
        [Fact]
        public void ShouldReturnDecimalArrayWhenValidArgsProvided()
        {
            string[] args = { "1.23", "4.56", "7.89" };
            int requiredArgs = 3;
            var converter = new ArgsToDecimals(args, requiredArgs);
            var result = converter.ToDecimals();
            Assert.Equal(3, result.Length);
            Assert.Equal(1.23m, result[0]);
            Assert.Equal(4.56m, result[1]);
            Assert.Equal(7.89m, result[2]);
        }

        [Fact]
        public void ShouldReturnEmptyArrayWhenEmptyArgsProvided()
        {
            string[] args = { };
            int requiredArgs = 0;
            var converter = new ArgsToDecimals(args, requiredArgs);
            var result = converter.ToDecimals();
            Assert.Empty(result);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionWhenIncorrectNumberOfArgsProvided()
        {
            string[] args = { "1.23", "4.56" };
            int requiredArgs = 3;
            var converter = new ArgsToDecimals(args, requiredArgs);
            var ex = Assert.Throws<ArgumentException>(() => converter.ToDecimals());
            Assert.Equal("Incorrect number of arguments.", ex.Message);
        }

        [Fact]
        public void ToDecimalsShouldThrowInvalidCastExceptionWhenArgIsNotValidDecimal()
        {
            string[] args = { "1.23", "invalid", "7.89" };
            int requiredArgs = 3;
            var converter = new ArgsToDecimals(args, requiredArgs);
            var ex = Assert.Throws<InvalidCastException>(() => converter.ToDecimals());
            Assert.Contains("Argument at index 1 is incorrect: invalid.", ex.Message);
        }

        [Fact]
        public void ToDecimalsShouldThrowInvalidCastExceptionWhenCommaIsUsedAsDecimalSeparator()
        {
            string[] args = { "1,23", "4.56", "7.89" };
            int requiredArgs = 3;
            var converter = new ArgsToDecimals(args, requiredArgs);
            var ex = Assert.Throws<InvalidCastException>(() => converter.ToDecimals());
            Assert.Contains("Incorrect format of number. Use a period as the decimal separator (dot) instead of a comma.", ex.InnerException!.Message);
        }
    }
}
