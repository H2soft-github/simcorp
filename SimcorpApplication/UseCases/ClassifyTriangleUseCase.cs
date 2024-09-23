using SimcorpCore.Aggregates;
using SimcorpCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpApplication.UseCases
{
    public class ClassifyTriangleUseCase : IClassifyTriangleUseCase
    {
        public string ClassifyTriangle(decimal sideA, decimal sideB, decimal sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            return triangle.Classify().ToString();
        }
    }
}
