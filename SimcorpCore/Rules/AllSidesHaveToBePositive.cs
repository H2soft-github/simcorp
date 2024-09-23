using SimcorpShared.Kernel.BuldingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpCore.Rules
{
    public class AllSidesHaveToBePositive(decimal[] sides) : IBusinessRule
    {
        public string Message => "All sides must be positive.";

        public bool IsBroken()
        {
            return sides.Any(x => x < 0);
        }
    }
}
