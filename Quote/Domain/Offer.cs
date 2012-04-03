namespace Quote.Domain
{
    public class Offer
    {
        public static Offer From(string line)
        {
            string[] values = line.Split(',');
            return new Offer
                       {
                           Lender = values[0],
                           Rate = double.Parse(values[1]),
                           Available = double.Parse(values[2])
                       };
        }

        public bool IsEmpty { get; set; }
        public string Lender { get; private set; }
        public double Rate { get; private set; }
        public double Available { get; private set; }

        public double RequestedAmount { get; set; }
        public double Monthly { get; set; }
        public double Total { get; set; }
    }

}