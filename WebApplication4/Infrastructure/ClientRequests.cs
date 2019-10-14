using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Infrastructure
{
   
    public class ClientRequests
    {
        public RestClient Client { get; set; } = new RestClient("http://api.nbp.pl/api/");

        public double Convert(double amount, string codeA, string codeX)
        {
            
                //get data
                RestRequest request1 = new RestRequest($"exchangerates/rates/a/{codeA}", Method.GET);
                CurrencyRates rateA = Client.Execute<CurrencyRates>(request1).Data;

                RestRequest request2 = new RestRequest($"exchangerates/rates/a/{codeX}", Method.GET);
                CurrencyRates rateX = Client.Execute<CurrencyRates>(request2).Data;

                //calc
                double rateForCodeAInPLN = rateA.Rates.First().Mid * amount;
                double result = rateForCodeAInPLN / rateX.Rates.First().Mid;
                return result;
           
        }


        public IEnumerable<Currency> GetCurrentsAndRates()
        {
            RestRequest request = new RestRequest($"exchangerates/tables/a", Method.GET);
            string tableStr = Client.Execute(request).Content;
            Table table = JsonConvert.DeserializeObject<List<Table>>(tableStr)[0];
            table.Currencies.Add(new Currency { Code = "PLN", CurrencyName="zloty", Price = 1 });          
            return table.Currencies;

        }

        public double ConvertPLNToX(double amount, string codeX)
        {
            RestRequest request = new RestRequest($"exchangerates/rates/a/{codeX}", Method.GET);
            CurrencyRates rateX = Client.Execute<CurrencyRates>(request).Data;

            double result = amount / rateX.Rates.First().Mid;
            return result;
        }

        public double ConvertXToPLN(double amount, string codeA)
        {

            RestRequest request = new RestRequest($"exchangerates/rates/a/{codeA}", Method.GET);
            CurrencyRates rateA = Client.Execute<CurrencyRates>(request).Data;

            double result = amount * rateA.Rates.First().Mid;
            return result;

        }


    }
}