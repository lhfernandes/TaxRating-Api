
namespace Domain.Entities
{
    public class TaxRate
    {
        public string Symbol { get; private set; }
        public double ValueBRL { get; private set; }
        public double ValueSymbol{ get; private set; }
        public double ValueRate { get; private set; }
        public DateTime Date { get; private set; }
        public string Etag { get; private set; }

        public TaxRate()
        {
            Symbol = string.Empty;
            ValueBRL = 0;
            ValueSymbol = 0;
            ValueRate = 0;
            Etag = string.Empty;
            Date = DateTime.Now;
        }
        public TaxRate(string symbol, double valSymbol, double valueBRL, string etag)
        {
            Symbol = symbol;
            ValueSymbol = valSymbol;
            ValueBRL = valueBRL;
            Date = DateTime.Now;
            Etag = etag;
            ValueRate = ValueBRL / ValueSymbol;
        }
    }
}
