
namespace InterestCalculator
{
    class InterestCalculator
    {

        public InterestCalculator(decimal money, double interest, int years, CalculateInterest del)
        {
            this.Result = del(money, interest, years);
        }

        public decimal Result { get; set; }
    }
}
