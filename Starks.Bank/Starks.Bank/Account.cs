using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starks.Bank
{
    public class Account
    {
        public string Id { get; set; }

        public Customer Customer { get; set; }

        public decimal Balance { get; set; }
    }
}
