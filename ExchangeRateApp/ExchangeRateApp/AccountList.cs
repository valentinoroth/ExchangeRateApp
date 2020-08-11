using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp
{
    class AccountList
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public Currency BaseCurrency { get; set; }
        
        public async Task<double> GetTotal()
        {
            var rates = await ExchangeRate.LoadRates(BaseCurrency);
            double somme = .0;
            foreach(var c in Accounts)
            {
                c.Rate = rates.GetRate(c.Currency);
                somme += c.Rate;
            }
            return somme;
        }
    }
}
