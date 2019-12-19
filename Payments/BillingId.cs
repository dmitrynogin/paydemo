using Newtonsoft.Json;
using Payments.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.String;

namespace Payments
{
    [TypeConverter(typeof(BillingIdTypeConverter))]
    [JsonConverter(typeof(BillingIdJsonConverter))]
    public class BillingId
    {
        public static BillingId Parse(string text) =>
            IsNullOrWhiteSpace(text) ? null :
            text.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries) is string[] p && p.Length == 2
                ? new BillingId(p[0], p[1]) 
                : throw new FormatException();

        public BillingId(string provider, string value) => 
            (Provider, Value) = (provider, value);

        public string Provider { get; }
        public string Value { get; }
        
        public override string ToString() => 
            $"{Provider}:{Value}";
    }
}
