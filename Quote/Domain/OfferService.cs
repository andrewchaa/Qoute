using System;
using System.Linq;

namespace Quote.Domain
{
    public class OfferService
    {
        private readonly IRepository _repository;

        public OfferService(IRepository repository)
        {
            _repository = repository;
        }


        public Offer FindMinimumRateFor(double requestedAmount)
        {
            var offers = _repository.FindAll(o => o.Available >= requestedAmount);
            if (!offers.Any())
                return new Offer {IsEmpty = true};

            var minimumOffer = offers.OrderBy(o => o.Rate).First();
            minimumOffer.RequestedAmount = requestedAmount;

            var calculator = new LoanCalculator(requestedAmount, minimumOffer.Rate, 36);
            minimumOffer.Monthly = calculator.Monthly;
            minimumOffer.Total = calculator.Total;

            return minimumOffer;
        }
    }
}