using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Quote.Domain;

namespace Quote.Test
{
    [TestFixture]
    public class LoanCalculatorTest
    {
        [Test]
        public void Monthly_Compounding_Interest()
        {
            const double amount = 1000;
            const double rate = 0.070;
            const int payments = 36;

            var calculator = new LoanCalculator(amount, rate, payments);
            
            Assert.That(calculator.Total, Is.EqualTo(1111.5754871533859d));
            Assert.That(calculator.Monthly, Is.EqualTo(30.877096865371833d));

        }

        [Test]
        public void Test()
        {
            double amount = 1000;
            double rate = 0.059;

            double total = amount * Math.Pow(1 + rate/12, 12*3);

            Console.WriteLine(total);
            Console.WriteLine(total/36);

            var principal = 1000;
            var interest = 0.070 / 12;
            var payments = 3 * 12;

            var x = Math.Pow(1 + interest, payments);
            var monthly = (principal * x * interest) / (x - 1);

            Console.WriteLine(monthly);
            Console.WriteLine(monthly * 36);
        }
    }
}
