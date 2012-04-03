using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Quote.Domain;

namespace Quote.Test
{
    [TestFixture]
    public class ServiceTest
    {
        private OfferRepository _offerRepository;
        private OfferService _service;

        [SetUp]
        public void BeforeEachTest()
        {
            _offerRepository = new OfferRepository(@"..\..\..\market.csv");
            _service = new OfferService(_offerRepository);
        }

        [Test]
        public void Should_Read_File()
        {
            var offers = _offerRepository.FindAll(); 
            
            Assert.That(offers.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void FindAll_Return_An_Entity_That_Has_Lender_Rate_Available()
        {
            var offer = _offerRepository.FindAll().First();

            Assert.That(offer.Lender, Is.EqualTo("Bob"));
        }

        [Test]
        public void FindAll_Can_Filter_By_Available()
        {
            var offers = _offerRepository.FindAll(a => a.Available <= 170);

            Assert.That(offers.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Service_FindMinimumRateFor_Return_The_Lowest_Rate_Given_Available_Amount()
        {
            var minOffer = _service.FindMinimumRateFor(170);

            Assert.That(minOffer.Rate, Is.EqualTo(0.069));
        }

        [Test]
        public void Loan_Amount_Bigger_Than_Market_Maximum_Available_Will_Result_In_Empty_Offer()
        {
            var emptyOffer = _service.FindMinimumRateFor(1000);

            Assert.That(emptyOffer.IsEmpty, Is.True);
        }


    }
}
