using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starks.Bank
{
    public class Account
    {
        string Id { get; }

        Customer Customer { get; }

        decimal Balance { get; }
    }
}
