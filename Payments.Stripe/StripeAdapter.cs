using System;
using System.Threading.Tasks;
using X.IoC;

namespace Payments
{
    public interface IStripeAdapter : IMainPaymentAdapter
    {
    }

    [Service]
    public class StripeAdapter : IStripeAdapter
    {
        StripeClient Client { get; } = new StripeClient();

        public async Task<BillingId> RegisterAsync(CreditCard card) =>
            new BillingId<IStripeAdapter>(await Client.RegisterAsync(card));

        public async Task ChargeAsync(BillingId id, decimal amount) =>
            await Client.Charge(id.Value, amount);
    }
}
