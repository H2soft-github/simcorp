using SimcorpApplication.UseCases;
using SimcorpShared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpTestsIntegration
{
    public class ClassifyTriangleUseCaseTests
    {
        [Fact]
        public void ClassifyTriangleShouldReturnEquilateralWhenAllSidesAreEqual()
        {
            var useCase = new ClassifyTriangleUseCase();
            var result = useCase.ClassifyTriangle(5, 5, 5);
            Assert.Equal("Equilateral", result);
        }

        [Fact]
        public void ClassifyTriangleShouldReturnIsoscelesWhenTwoSidesAreEqual()
        {
            var useCase = new ClassifyTriangleUseCase();
            var result = useCase.ClassifyTriangle(5, 5, 8);
            Assert.Equal("Isosceles", result);
        }

        [Fact]
        public void ClassifyTriangleShouldReturnScaleneWhenAllSidesAreDifferent()
        {
            var useCase = new ClassifyTriangleUseCase();
            var result = useCase.ClassifyTriangle(5, 6, 7);
            Assert.Equal("Scalene", result);
        }

        [Fact]
        public void ClassifyTriangleShouldReturnErrorMessageWhenInvalidTriangle()
        {
            var useCase = new ClassifyTriangleUseCase();
            var ex = Assert.Throws<BusinessRuleValidationException>(() => useCase.ClassifyTriangle(1, 1, 3));
            Assert.Equal("The sum of any two sides must be greater than the third side.", ex.Message);
        }
    }
}
