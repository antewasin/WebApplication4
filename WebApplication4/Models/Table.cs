using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Table
    {
        [JsonProperty("rates")]
        public List<Currency> Currencies { get; set; }

      

        

    }
}