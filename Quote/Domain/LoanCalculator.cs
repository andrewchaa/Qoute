using System;

namespace Quote.Domain
{
    public class LoanCalculator
    {
        private readonly double _amount;
        private readonly int _payments;
        private readonly double _monthlyRate;

        public LoanCalculator(double amount, double rate, int payments)
        {
            _amount = amount;
            _payments = payments;
            _monthlyRate = rate / 12;
        }

        public double Monthly
        {
            get 
            { 
                double x = Math.Pow(1 + (_monthlyRate), _payments);
                return (_amount * x *_monthlyRate) / (x - 1);
            }
        }

        public double Total 
        { 
            get { return Monthly * _payments; }
        }
    }
}