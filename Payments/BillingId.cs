using Newtonsoft.Json;
using Payments.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Payments
{
    [TypeConverter(typeof(BillingIdTypeConverter))]
    [JsonConverter(typeof(BillingIdJsonConverter))]
    public abstract class BillingId
    {
        public static BillingId Parse(string text)
        {
            var parts = text.Split('/');
            return (BillingId)Activator.CreateInstance(
                typeof(BillingId<>).MakeGenericType(Type.GetType(parts[0])),
                parts[1]);
        }

        protected BillingId(string value) => Value = value;
        public string Value { get; }
        public abstract Type Provider { get; }
        public override string ToString() => 
            $"{Provider.AssemblyQualifiedName}/{Value}";
    }

    public class BillingId<TProvider> : BillingId 
        where TProvider : IPaymentProvider
    {
        public BillingId(string value) : base(value) { }
        public override Type Provider => typeof(TProvider);
    }
}
