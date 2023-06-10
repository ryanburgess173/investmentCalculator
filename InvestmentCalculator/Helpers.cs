using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator
{
    internal class Helpers
    {
        public bool IsNumeric(string input)
        {
            if (input != null)
            {
                return double.TryParse(input, out var result);
            }
            else
            {
                return false;
            }
        }
    }
}
