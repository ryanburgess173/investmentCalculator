using InvestmentCalculator;
using Newtonsoft.Json;

Helpers helperMethods = new Helpers();
void main()
{
    InvestmentDataObject investmentData = ParseJsonDocument();
    UserVariables userVariables = GetUserVariables();
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
    catch(FileNotFoundException e)
    {
        Console.WriteLine("File doesn't exist.\n" + e);
    }
    catch(Exception e)
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
    }catch(Exception e)
    {
        Console.WriteLine(e);
    }
    return userVariables;
}
main();