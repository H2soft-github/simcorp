using SimcorpCore.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpTestsUnit
{
    public class BusinessRulesTests
    {
        [Fact]
        public void IsBrokenShouldReturnTrueWhenAnySideIsNonPositive()
        {
            var rule = new AllSidesHaveToBePositive(new decimal[] { 1, -1, 3 });
            var result = rule.IsBroken();
            Assert.True(result);
        }

        [Fact]
        public void IsBrokenShouldReturnFalseWhenAllSidesArePositive()
        {
            var rule = new AllSidesHaveToBePositive(new decimal[] { 1, 2, 3 });
            var result = rule.IsBroken();
            Assert.False(result);
        }

        [Fact]
        public void IsBrokenShouldReturnTrueWhenSidesDoNotFormTriangle()
        {
            var rule = new MustBeTriangle(1, 1, 3);
            var result = rule.IsBroken();
            Assert.True(result);
        }

        [Fact]
        public void IsBrokenShouldReturnFalseWhenSidesFormValidTriangle()
        {
            var rule = new MustBeTriangle(3, 4, 5);
            var result = rule.IsBroken();
            Assert.False(result);
        }
    }
}
