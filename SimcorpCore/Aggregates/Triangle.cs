using SimcorpCore.Enums;
using SimcorpCore.Rules;
using SimcorpShared.Kernel.BuldingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpCore.Aggregates
{
    public class Triangle : AggregateRoot
    {
        public decimal SideA { get; }
        public  decimal SideB { get; }
        public decimal SideC { get; }

        public Triangle(decimal sideA, decimal sideB, decimal sideC)
        {
            CheckRule(new AllSidesHaveToBePositive(new decimal[] { sideA, sideB, sideC }));
            CheckRule(new MustBeTriangle(sideA, sideB, sideC));
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public TriangleType Classify()
        {
            if (SideA == SideB && SideB == SideC)
                return TriangleType.Equilateral;
            else if (SideA == SideB || SideB == SideC || SideA == SideC)
                return TriangleType.Isosceles;
            else
                return TriangleType.Scalene;
        }
    }
}
