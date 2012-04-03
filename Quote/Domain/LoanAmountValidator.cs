namespace Quote.Domain
{
    public class LoanAmountValidator : IValidator
    {
        private readonly double _amount;

        public LoanAmountValidator(double amount)
        {
            _amount = amount;
        }

        public bool Validate()
        {
            return _amount >= 1000 && _amount <= 15000;
        }
    }
}
