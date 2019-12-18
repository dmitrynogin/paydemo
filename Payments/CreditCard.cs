namespace Payments
{
    public class CreditCard
    {
        public CreditCard(string number, string name, string csv)
        {
            Number = number;
            Name = name;
            Csv = csv;
        }

        public string Number { get; }
        public string Name { get; }
        public string Csv { get; }
    }
}