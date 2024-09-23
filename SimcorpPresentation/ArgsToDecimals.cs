using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpPresentation
{
    public class ArgsToDecimals(string[] args, int requiredArgs)
    {
        public decimal[] ToDecimals()
        {
            if (args.Length != requiredArgs)
            {
                throw new ArgumentException("Incorrect number of arguments.");
            }
            List<decimal> result = new List<decimal>();
            int index = 0;
            foreach (string arg in args)
            {
                try
                {
                    if (arg.Contains(','))
                    {
                        throw new FormatException("Incorrect format of number. Use a period as the decimal separator (dot) instead of a comma.");
                    }
                    result.Add(decimal.Parse(arg, CultureInfo.InvariantCulture));
                }
                catch (Exception ex)
                {
                    throw new InvalidCastException($"Argument at index {index} is incorrect: {arg}.", ex);
                }
                index++;
            }
            return result.ToArray();
        }
    }
}
