using InvestmentCalculator;
using Newtonsoft.Json;

internal class Program
{
    static FundSimulators simulator = new FundSimulators();
    static Helpers helperMethods = new Helpers();
    private static void Main(string[] args)
    {
        void main()
        {
            InvestmentDataObject investmentData = ParseJsonDocument();
            UserVariables userVariables = GetUserVariables();
            CalculateAndOutputRoadmap(investmentData, userVariables);
        }
        void CalculateAndOutputRoadmap(InvestmentDataObject investmentData, UserVariables userVariables)
        {
            Console.WriteLine("You are starting with ${0}", userVariables.PrincipalLumpSum);
            bool optionChosen = false;
            while (!optionChosen)
            {
                Console.WriteLine("========================================Investment Options=======================================");
                Console.WriteLine("1. GrowthFund. Just Stock Mutual Funds. Maximum Growth");
                Console.WriteLine("2. TraditionalFund. 50% Stock Funds, 25% Bond Funds, 10% Gold, 5% Silver, 10% Real Estate Funds");
                Console.WriteLine("3. CashFlowFund. Maximum Cash Flow");
                Console.WriteLine("4. BalancedFund. Perfectly Balanced Fund");
                Console.WriteLine("5. FiftyFiftyStockFund. 50% Growth, 50% Cash Flow");
                Console.WriteLine("6. BalancedClassesFund. 25% Stocks, 25% Bonds, 25% Real Estate, 25% Gold");
                Console.WriteLine("7. BalancedLeanStocksFund. 20% Growth, 20% Dividends, 20% Bonds, 20% Real-Estate, 15% Gold, 5% Silver");
                Console.WriteLine("8. Fund2023. 50% Growth, 10% Dividends, 20% Bonds, 20% Gold");
                Console.WriteLine("9. ReservesFund. 10% Growth, 10% Dividends, 40% Bonds, 20% Gold, 10% Silver, 10% Real-Estate");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        simulator.GrowthFund(investmentData, userVariables.PrincipalLumpSum, userVariables.TimelineInMonths);
                        break;
                    case 2:
                        simulator.TraditionalFund(investmentData, userVariables.PrincipalLumpSum, userVariables.TimelineInMonths);
                        break;
                    case 0:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
        InvestmentDataObject ParseJsonDocument()
        {
            InvestmentDataObject obj = new InvestmentDataObject();
            try
            {
                using (StreamReader r = new StreamReader("investmentMetrics.json"))
                {
                    string json = r.ReadToEnd();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    obj = JsonConvert.DeserializeObject<InvestmentDataObject>(json, settings);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File doesn't exist.\n" + e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return obj;
        }

        UserVariables GetUserVariables()
        {
            UserVariables userVariables = new UserVariables();
            try
            {
                bool firstNotSatisfied = true;
                bool secondNotSatisfied = true;
                string lumpSumAmount = "";
                string numberOfMonths = "";
                while (firstNotSatisfied)
                {
                    Console.Write("Enter the total lump sum amount you'd like to invest: $");
                    lumpSumAmount = Console.ReadLine() ?? "";
                    if (helperMethods.IsNumeric(lumpSumAmount))
                    {
                        firstNotSatisfied = false;
                    }
                    else
                    {
                        Console.WriteLine("Please re-enter a numeric value.");
                    }
                }
                while (secondNotSatisfied)
                {
                    Console.Write("Enter the number of months you'd like to invest this over: ");
                    numberOfMonths = Console.ReadLine() ?? "";
                    if (helperMethods.IsNumeric(numberOfMonths))
                    {
                        secondNotSatisfied = false;
                    }
                    else
                    {
                        Console.WriteLine("Please re-enter a numeric value.");
                    }
                }
                userVariables = new UserVariables(int.Parse(lumpSumAmount), int.Parse(numberOfMonths));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return userVariables;
        }
        main();
    }
}