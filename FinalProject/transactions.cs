using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public double AmountGEL { get; set; }
        public double AmountUSD { get; set; }
        public double AmountEUR { get; set; }
    }
}
