using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLibrary
{
    public class TrapCalculatorParallel : ICalculator
    {
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            double [] mass = new double[n];
            double h = (b - a) / n;
            double sum = 0;
            Parallel.For(1, n, i => mass[i] = f(a + h * i));
            //sum = mass.Sum();
            foreach (double value in mass)
            {
                sum += value;
            }
            sum += (f(a) + f(b)) / 2;
            return sum * h;
        }
    }
}
