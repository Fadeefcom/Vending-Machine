using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Entities
{
    public class CoinType
    {
        public int Id { get; }

        public int Value { get; set; }

        public string Name { get; set; }

        public bool Disabled { get; set; }

        public DateTime Created { get; } = DateTime.Now;

        public ICollection<CoinRecieved> CoinsRecieved { get; set; } = new List<CoinRecieved>();

        public ICollection<CoinReturned> CoinsReturned { get; set; }  = new List<CoinReturned>();

    }
}
