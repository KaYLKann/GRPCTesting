using System;

namespace Calculator
{
    public class ExponentiationOperation : IExponentiationOperation<double>, IExponentiationOperation<int>
    {
        public double Calculate(double value, double power)
        {
            return Math.Pow(value, power);
        }

        public int Calculate(int value, int power)
        {
            return (int) Math.Pow(value, power);
        }
    }
}