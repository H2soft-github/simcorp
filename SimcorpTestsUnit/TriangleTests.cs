using SimcorpCore.Aggregates;
using SimcorpCore.Enums;
using SimcorpShared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpTestsUnit
{
    public class TriangleTests
    {
        [Fact]
        public void ClassifyShouldReturnEquilateralWhenAllSidesAreEqual()
        {
            var triangle = new Triangle(5, 5, 5);
            var result = triangle.Classify();
            Assert.Equal(TriangleType.Equilateral, result);
        }

        [Fact]
        public void ClassifyShouldReturnIsoscelesWhenTwoSidesAreEqual()
        {
            var triangle = new Triangle(5, 5, 8);
            var result = triangle.Classify();
            Assert.Equal(TriangleType.Isosceles, result);
        }

        [Fact]
        public void ClassifyShouldReturnScaleneWhenAllSidesAreDifferent()
        {
            var triangle = new Triangle(5, 6, 7);
            var result = triangle.Classify();
            Assert.Equal(TriangleType.Scalene, result);
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenAnySideIsZeroOrNegative()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Triangle(0, 5, 7));
            Assert.Throws<BusinessRuleValidationException>(() => new Triangle(5, -5, 7));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenSidesDoNotFormTriangle()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Triangle(1, 1, 3));
        }
    }
}
