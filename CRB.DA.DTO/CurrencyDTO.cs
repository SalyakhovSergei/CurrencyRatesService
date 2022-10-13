using System;

namespace CRB.DA.DTO
{
    public class CurrencyDTO
    {
        public string Name { get; set; }
        public string NumericCode { get; set; }
        public string AlphaCode { get; set; }
        public decimal Price { get; set; }
        public decimal PriceFor1Unit { get; set; }
        public int Scale { get; set; }
        public DateTime Date { get; set; }

    }
}