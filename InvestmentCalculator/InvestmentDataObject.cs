using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator
{
    public class InvestmentDataObject
    {
        public List<Fund> StockETFs { get; set; }
        public List<Fund> RealEstateFunds { get; set; }
        public List<Fund> BondFunds { get; set; }
        public SavingsAccountType SavingsAccount { get; set; }
        public double ReturnOnGold { get; set; }
        public double ReturnOnSilver { get; set; }
    }
}
