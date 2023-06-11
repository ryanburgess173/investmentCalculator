using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator
{
    public class Helpers
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
        public Fund FindInvestmentProduct(List<Fund> funds, string ticker)
        {
            bool fundFound = false;
            Fund fundToReturn = new Fund();
            foreach(Fund fund in funds)
            {
                if (fund.Ticker == ticker)
                {
                    fundFound = true;
                    fundToReturn = fund;
                }
            }
            if(fundFound == false)
            {
                Console.WriteLine("\n\nFund not found.\n\n");
                return fundToReturn;
            }
            return fundToReturn;
        }
    }
}
