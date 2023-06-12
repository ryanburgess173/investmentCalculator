using System;
using System.Collections.Generic;
using InvestmentCalculator;

namespace InvestmentCalculator
{
    public class FundSimulators
	{
        public Helpers helperMethods = new Helpers();
        public FundSimulators()
		{
			
		}
        public void GrowthFund(InvestmentDataObject investmentData, double principal, int timeline)
        {
            List<string> fundsNeeded = new List<string>() { "FSELX", "FMILX", "FOSFX", "FSCSX", "FSMEX", "FSHOX", "FAGIX" };
            List<double> allocations = new List<double>() { 0.15, 0.3, 0.1, 0.15, 0.1, 0.1, 0.1 };
            BaseSimulator(fundsNeeded, allocations, investmentData, principal, timeline);
        }
        public void TraditionalFund(InvestmentDataObject investmentData, double principal, int timeline)
        {
            List<string> fundsNeeded = new List<string>() { "FSELX", "FMILX", "FOSFX", "FSCSX", "FSMEX", "VNQ", "FSHOX", "FAGIX", "Gold", "Silver" };
            List<double> allocations = new List<double>() { 0.1, 0.1, 0.1, 0.1, 0.1, 0.075, 0.025, 0.25, 0.15, 0.05 };
            BaseSimulator(fundsNeeded, allocations, investmentData, principal, timeline);
        }
        public void CashFlowFund(InvestmentDataObject investmentData, double principal, int timeline)
        {
            List<string> fundsNeeded = new List<string>() { "VYM", "VYMI", "FAGIX", "BND", "ANGL" };
            List<double> allocations = new List<double>() { 0.35, 0.35, 0.1, 0.1, 0.1 };
            BaseSimulator(fundsNeeded, allocations, investmentData, principal, timeline);
        }
        public void BaseSimulator(List<string> fundsNeeded, List<double> allocations, InvestmentDataObject investmentData, double principal, int timeline)
        {
            double SavingsBalance = principal;
            List<double> fundBalances = new List<double>();
            foreach(string fund in fundsNeeded)
            {
                fundBalances.Add(0.0);
            }

            Console.WriteLine("\n============================================================Balances============================================================");
            Console.Write("|\tSavings Account");
            foreach (string fundName in fundsNeeded)
            {
                Console.Write("\t|\t{0}", fundName);
            }
            Console.Write("\t|\tCash Flow\t|\n");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            double totalCashFlow;
            for (int i = 0; i < timeline; i++)
            {
                totalCashFlow = 0.0;
                for (int j = 0; j < fundsNeeded.Count; j++)
                {
                    Fund currentFund = helperMethods.FindInvestmentProduct(investmentData.Funds, fundsNeeded[j]);
                    double fundCapitalAppreciationRatePerMonth = (currentFund.TotalReturnsOverLife - currentFund.Yield) / 12;
                    double fundCashFlowRatePerMonth = currentFund.Yield / 12;
                    totalCashFlow += fundBalances[j] * fundCashFlowRatePerMonth;
                    fundBalances[j] = fundBalances[j] + (fundBalances[j] * fundCapitalAppreciationRatePerMonth) + ((principal / timeline) * allocations[j]);
                    Console.Write("\t|\t${0}", Math.Round(fundBalances[j], 2));
                }
                Console.Write("\t|\t${0}\t|\n", Math.Round(totalCashFlow));
            }
        }
    }
}

