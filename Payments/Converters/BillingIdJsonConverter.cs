using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Payments.Converters
{
    public class BillingIdJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            objectType == typeof(BillingId);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            BillingId.Parse(serializer.Deserialize<string>(reader));

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            serializer.Serialize(writer, value?.ToString());
    }
}
