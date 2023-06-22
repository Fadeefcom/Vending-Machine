using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Entities
{
    public class CoinReturned
    {
        public int Id { get; set; }

        public int CoinId { get; set; }

        public int TransactionId { get; set; }

        public TransactionPurshared TransactionPurshared { get; set; }

        public CoinType CoinType { get; set; }
    }
}
