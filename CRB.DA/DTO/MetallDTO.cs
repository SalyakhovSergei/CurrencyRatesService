using System;
using Dapper.Contrib.Extensions;

namespace CRB.DA.DTO
{
    [Table("[crb].[metall]")]
    public class MetallDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string AlphaCode { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset RecordDate { get; set; }

    }
}