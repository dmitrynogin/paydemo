using System;
using System.Threading.Tasks;
using X.IoC;

namespace Payments
{
    public interface IStripeProvider : IMainPaymentProvider
    {
    }

    [Service]
    public class StripeProvider : IStripeProvider
    {
        StripeClient Client { get; } = new StripeClient();

        public string Name => "Stripe";

        public async Task<BillingId> RegisterAsync(CreditCard card) =>
            new BillingId(Name, await Client.RegisterAsync(card));

        public async Task ChargeAsync(BillingId id, decimal amount) =>
            await Client.Charge(id.Value, amount);
    }
}
