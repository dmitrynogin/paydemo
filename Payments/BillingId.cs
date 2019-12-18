using System;
using System.Collections.Generic;
using System.Text;

namespace Payments
{
    public abstract class BillingId
    {
        protected BillingId(string value) => Value = value;
        public string Value { get; }
        public abstract Type Provider { get; }
    }

    public class BillingId<TProvider> : BillingId 
        where TProvider : IPaymentProvider
    {
        public BillingId(string value) : base(value) { }
        public override Type Provider => typeof(TProvider);
    }
}
