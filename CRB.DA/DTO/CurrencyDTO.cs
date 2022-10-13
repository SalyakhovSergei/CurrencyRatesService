using System;
using Dapper.Contrib.Extensions;

namespace CRB.DA.DTO
{
    [Table("crb.Currency")]
    public class CurrencyDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumericCode { get; set; }
        public string AlphaCode { get; set; }
        public decimal Price { get; set; }
        public int Scale { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset RecordDate { get; set; }

    }
}