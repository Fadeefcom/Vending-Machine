using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Entities
{
    public class TransactionPurshared
    {
        public int Id { get; }

        public int AmountPurshared { get; set;  }

        public required ICollection<CatalogItem> CatalogItems { get; set; }

        public double Withdrawal { get; set; }

        public double OverDraft { get; set; }

        public required ICollection<CoinRecieved> CoinsRecieved { get; set; }

        public required ICollection<CoinReturned> CoinsReturned { get; set; }

        public DateTime Created { get; } = DateTime.Now;
    }
}
