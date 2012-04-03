using System;
using System.Collections.Generic;

namespace Quote.Domain
{
    public interface IRepository
    {
        IEnumerable<Offer> FindAll();
        IEnumerable<Offer> FindAll(Func<Offer, bool> func);
    }
}