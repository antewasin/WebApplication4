using Newtonsoft.Json;
using System;

namespace WebApplication4.Models
{
    public class Currency
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonProperty("currency")]

        public string CurrencyName { get; set; }
        public string Code { get; set; }
        [JsonProperty("mid")]
        public double Price { get; set; }

       

    }
}