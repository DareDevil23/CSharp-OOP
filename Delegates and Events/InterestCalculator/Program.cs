using System;

namespace InterestCalculator
{
    public delegate decimal CalculateInterest(decimal sumOfMoney, double interest, int years);

    class Program
    {
        public static decimal GetSimpleInterest(decimal sumOfMoney, double interest, int years)
        {
            return sumOfMoney * (decimal)(1 + interest/100 * years);
        }

        public static decimal GetCompoundInterest(decimal sumOfMoney, double interest, int years)
        {
            return sumOfMoney * (decimal) Math.Pow((1 + interest / 1200 ), years * 12);
        }

        static void Main(string[] args)
        {

            CalculateInterest del = GetCompoundInterest;
            InterestCalculator interestCalculator = new InterestCalculator(500, 5.6, 10, del);
            Console.WriteLine($"{interestCalculator.Result:F4}");


            CalculateInterest deleg = GetSimpleInterest;
            InterestCalculator calc = new InterestCalculator(2500, 7.2, 15, deleg);
            Console.WriteLine($"{calc.Result:F4}");
        }
    }
}
