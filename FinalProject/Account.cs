using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinalProject
{
    internal class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CardDetails CardDetails { get; set; }       
        public string PinCode { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; } 
    }
}
