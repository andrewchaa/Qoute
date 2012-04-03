using System;
using Quote.Domain;

namespace Quote
{
    class Program
    {
        static void Main(string[] args)
        {
            if (ValidateArguments(args)) return;

            double requestedAmount = double.Parse(args[1]);
            string filePath = args[0];

            if (ValidateRequestedAmount(requestedAmount)) return;

            var service = new OfferService(new OfferRepository(filePath));
            var offer = service.FindMinimumRateFor(requestedAmount);

            if (ValidateOffer(requestedAmount, offer)) return;

            DisplayOfferDetails(offer);
        }

        private static void DisplayOfferDetails(Offer offer)
        {
            Console.WriteLine("Requested amount: £{0}", offer.RequestedAmount);
            Console.WriteLine("Rate: {0}", offer.Rate.ToString("#0.0%"));
            Console.WriteLine("Monthly repayment: £{0}", offer.Monthly.ToString("#0.00"));
            Console.WriteLine("Total repayment: £{0}", offer.Total.ToString("#0.00"));
        }

        private static bool ValidateOffer(double requestedAmount, Offer offer)
        {
            if (offer.IsEmpty)
            {
                Console.WriteLine("Sorry, it is not possible to provide a quote for £{0} at this time.", requestedAmount);
                return true;
            }
            return false;
        }

        private static bool ValidateRequestedAmount(double requestedAmount)
        {
            IValidator validator = new LoanAmountValidator(requestedAmount);
            bool result = validator.Validate();
            if (!result)
            {
                Console.WriteLine("Please enter the loan amount between £1000 and £15000.");
                return true;
            }
            return false;
        }

        private static bool ValidateArguments(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: quote.exe [market_file] [loan_amount]");
                return true;
            }
            return false;
        }
    }
}
