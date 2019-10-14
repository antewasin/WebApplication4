using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class CurrencyRates
    {
        public string Code { get; set; }
        [JsonProperty("currency")]
        public string CurrencyName { get; set; }
        public List<Rate> Rates { get; set; }
    }
}