using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp
{
    public class ExchangeRate
    {
        public Currency Base { get; set; }

        [JsonProperty]
        private Dictionary<Currency, Double> rates { get; set; }

        public DateTime Date { get; set; }

        static async public Task<ExchangeRate> LoadRates(Currency Base)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.exchangeratesapi.io/latest?base={Base}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<ExchangeRate>(); 
            }
            return null;
        }

        internal object GetRate(object currency)
        {
            throw new NotImplementedException();
        }

        public double GetRate(Currency currency)
        {

            if (!rates.TryGetValue(currency, out var rate) && currency == Base)
                rate = 1.0;
            return rate;
        }
    }
}
