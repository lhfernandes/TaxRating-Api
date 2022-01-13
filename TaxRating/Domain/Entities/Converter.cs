using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ConverterTax
    {
        public double ValConverted { get; private set; }
        public int Amount { get; private set; }
        public double TxConversion { get; private set; }
        public double TxSegment { get; private set; }
        public string Symbol { get; private set; }
        public int Segment { get; private set; }

        public ConverterTax()
        {

        }

        public ConverterTax(int amount,int segment)
        {
            Amount = amount;
            Segment = segment;
        }

        public void Convert( double txConv, double txSeb)
        {            
            TxConversion = txConv;
            TxSegment = txSeb;
            ValConverted = (Amount * TxConversion) * (1 + TxSegment);           
        }

        public string SymbolToUpper()
        {
            return Symbol.ToUpper();
        }

        
    }
}
