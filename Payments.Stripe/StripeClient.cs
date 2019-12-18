using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments
{
    class StripeClient
    {
        internal Task<string> RegisterAsync(CreditCard card) => 
            throw new NotImplementedException();

        internal Task Charge(string value, decimal amount) => 
            throw new NotImplementedException();
    }
}
