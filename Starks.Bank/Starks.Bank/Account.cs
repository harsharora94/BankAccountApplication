using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starks.Bank
{
    public class Account
    {
        public string Id { get; }

        public Customer Customer { get; }

        public decimal Balance { get; }
    }
}
