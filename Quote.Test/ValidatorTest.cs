using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Quote.Domain;

namespace Quote.Test
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test]
        public void Loan_Amount_Should_Be_Between_1000_And_15000()
        {
            decimal loan = 999m;
            var validator = new LoanAmountValidator(999);
            bool result = validator.Validate();

            Assert.That(result, Is.False);
        }
    }
}
