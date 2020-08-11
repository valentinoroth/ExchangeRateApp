using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp
{
    class Account
    {
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public double Value
        {
            get
            {
                double v = .0;
                v = Amount / Rate;
                return v;
            }
        }
    }
}
