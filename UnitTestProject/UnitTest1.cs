using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculateLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Correct_Rectangle_Calculator
    {
        [TestMethod]
        public void Correct_Rectangle_Method_1()
        {
            //arrange
            double expected = 36458.33333;
            double a = 25;
            double b = 50;
            long n = 10000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = rectangleCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void Correct_Rectangle_Method_2()
        {
            //arrange
            double expected = 54197.59134;
            double a = 1;
            double b = 100;
            long n = 10000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => 11 * x - Math.Log(11 * x) - 2;

            //act
            double actual = rectangleCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);
        }
    }

    [TestClass]
    public class Correct_Trap_Calculator
    {
        [TestMethod]
        public void Correct_Trap_Method_1()
        {
            //arrange
            double expected = 36458.33333;
            double a = 25;
            double b = 50;
            long n = 10000;
            TrapCalculator trapCalculator = new TrapCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = trapCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void Correct_Trap_Method_2()
        {
            //arrange
            double expected = 54197.59134;
            double a = 1;
            double b = 100;
            long n = 10000;
            TrapCalculator trapCalculator = new TrapCalculator();
            Func<double, double> f = x => 11 * x - Math.Log(11 * x) - 2;

            //act
            double actual = trapCalculator.Calculate(a, b, n, f);

            //assert

            Assert.AreEqual(expected, actual, 0.0001);
        }
    }

    [TestClass]
    public class Test_Correct_Argunments
    {
        [TestMethod]
        public void Test_Correct_A_and_B()
        {
            //arrange
            double a = 100;
            double b = 1;
            long n = 10;
            TrapCalculator trapCalculator = new TrapCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = trapCalculator.Calculate(a, b, n, f);
        }

        [TestMethod]
        public void Test_Correct_N()
        {
            //arrange
            double a = 100;
            double b = 1;
            long n = -10;
            TrapCalculator trapCalculator = new TrapCalculator();
            Func<double, double> f = x => x * x;

            //act
            double actual = trapCalculator.Calculate(a, b, n, f);
        }
    }
}
