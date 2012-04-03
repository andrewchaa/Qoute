using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Quote.Domain
{
    public class OfferRepository : IRepository
    {
        private readonly string _filePath;
        public OfferRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Offer> FindAll()
        {
            var lines = File.ReadAllLines(_filePath).ToList();
            lines.RemoveAt(0);

            return lines.Select(line => Offer.From(line)).ToList();
        }

        public IEnumerable<Offer> FindAll(Func<Offer, bool> func)
        {
            return FindAll().Where(func);
        }
    }
}