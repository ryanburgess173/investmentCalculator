using System;
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
            double SavingsAccountBalance = principal;
            double CashFlowFromSavings = 0.0;

            Fund FSELX_Product = new Fund();
            double FSELX_Capital_Appreciation_Rate = 0.0;
            double FSELX_Balance = 0.0;
            double CashFlowFromFSELX = 0.0;

            Fund FMILX_Product = new Fund();
            double FMILX_Capital_Appreciation_Rate = 0.0;
            double FMILX_Balance = 0.0;
            double CashFlowFromFMILX = 0.0;

            Fund FOSFX_Product = new Fund();
            double FOSFX_Capital_Appreciation_Rate = 0.0;
            double FOSFX_Balance = 0.0;
            double CashFlowFromFOSFX = 0.0;

            Fund FSCSX_Product = new Fund();
            double FSCSX_Capital_Appreciation_Rate = 0.0;
            double FSCSX_Balance = 0.0;
            double CashFlowFromFSXSX = 0.0;

            Fund FSMEX_Product = new Fund();
            double FSMEX_Capital_Appreciation_Rate = 0.0;
            double FSMEX_Balance = 0.0;
            double CashFlowFromFSMEX = 0.0;

            double TotalCashFlow = 0.0;
            Console.WriteLine("\n============================================================Balances============================================================");
            Console.WriteLine("|\tSavings Account\t|\tFSELX\t|\tFMILX\t|\tFOSXFX\t|\tFSCSX\t|\tFSMEX\t|\tMonth's Cash Flow\t|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

            for(int i=0; i<timeline; i++)
            {
                SavingsAccountBalance = SavingsAccountBalance - (principal/timeline);
                CashFlowFromSavings = (SavingsAccountBalance * (investmentData.SavingsAccount.InterestRate / 12));

                FSELX_Product = helperMethods.FindInvestmentProduct(investmentData.StockETFs, "FSELX");
                FSELX_Capital_Appreciation_Rate = ((FSELX_Product.TotalReturnsOverLife - FSELX_Product.Yield) / 12);
                FSELX_Balance = FSELX_Balance + (FSELX_Balance * FSELX_Capital_Appreciation_Rate) + ((principal / timeline)*0.2);
                CashFlowFromFSELX = FSELX_Balance * (FSELX_Product.Yield / 12);

                FMILX_Product = helperMethods.FindInvestmentProduct(investmentData.StockETFs, "FMILX");
                FMILX_Capital_Appreciation_Rate = ((FMILX_Product.TotalReturnsOverLife - FMILX_Product.Yield) / 12);
                FMILX_Balance = FMILX_Balance + (FMILX_Balance * FMILX_Capital_Appreciation_Rate) + ((principal / timeline) * 0.2);
                CashFlowFromFMILX = FMILX_Balance * (FMILX_Product.Yield / 12);

                TotalCashFlow = CashFlowFromSavings + CashFlowFromFSELX + CashFlowFromFMILX;
                Console.WriteLine("|\t${0}\t|\t${1}\t|\t${2}\t|\t${3}\t|\t${4}\t|\t${5}\t|\t${6}\t|",
                    Math.Round(SavingsAccountBalance, 2), Math.Round(FSELX_Balance, 2), Math.Round(FMILX_Balance, 2), FOSFX_Balance, FSCSX_Balance, FSMEX_Balance, TotalCashFlow);
            }
        }
        public void TraditionalFund(InvestmentDataObject investmentData, double principal, int timeline)
        {
            Console.WriteLine("Traditional Fund");
        }
    }
}

