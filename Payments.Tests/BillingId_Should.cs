using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Payments.Tests
{
    [TestClass]
    public class BillingId_Should
    {
        [TestMethod]
        public void Stringify()
        {
            BillingId id = new BillingId<IStripeProvider>("test");            

            var text = id.ToString();
            var copy = BillingId.Parse(text);

            Assert.IsInstanceOfType(copy, typeof(BillingId<IStripeProvider>));
            Assert.AreEqual("test", copy.Value);
        }

        [TestMethod]
        public void Serialize()
        {
            BillingId id = new BillingId<IStripeProvider>("test");

            var json = JsonConvert.SerializeObject(id);
            var copy = JsonConvert.DeserializeObject<BillingId>(json);

            Assert.IsInstanceOfType(copy, typeof(BillingId<IStripeProvider>));
            Assert.AreEqual("test", copy.Value);
        }

        [TestMethod]
        public void Convert()
        {
            BillingId id = new BillingId<IStripeProvider>("test");

            var converter = TypeDescriptor.GetConverter(id);
            var text = converter.ConvertTo(id, typeof(string));
            var copy = (BillingId)converter.ConvertFrom(text);

            Assert.IsInstanceOfType(copy, typeof(BillingId<IStripeProvider>));
            Assert.AreEqual("test", copy.Value);
        }
    }
}
