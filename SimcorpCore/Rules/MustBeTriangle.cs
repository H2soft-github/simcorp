using SimcorpShared.Kernel.BuldingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpCore.Rules
{
    public class MustBeTriangle(decimal sideA, decimal sideB, decimal sideC) : IBusinessRule
    {
        public string Message => "The sum of any two sides must be greater than the third side.";

        public bool IsBroken()
        {
            return (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA);
        }
    }
}
