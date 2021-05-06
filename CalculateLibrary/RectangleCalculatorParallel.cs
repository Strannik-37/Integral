using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLibrary
{
    public class RectangleCalculatorParallel : ICalculator
    {
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            double[] mass = new double[n];
            double h = (b - a) / n;
            a += h * 0.5;
            double sum = 0;
            Parallel.For(0, n, i => mass[i] = f(a + h * i));
            sum = mass.Sum();
            return sum * h;
        }
    }
}
