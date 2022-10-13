using System;

namespace CRB.DA.Responses
{
    public class CurrencyResponse
    {
        //данный класс создан исключительно для получения запросов из БД ввиду того что Code и NumericCode не мапятся в сущность CurrencyDTO
        public int Id { get; set; }
        public string Name { get; set; }
        public string Numeric_Code { get; set; }
        public string Alpha_Code { get; set; }
        public decimal Price { get; set; }
        public int Scale { get; set; }
        public DateTime Date { get; set; }
    }
}