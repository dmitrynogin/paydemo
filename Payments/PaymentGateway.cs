using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.IoC;

namespace Payments
{
    [Service]
    public class PaymentGateway : IPaymentGateway
    {
        public PaymentGateway(IServiceProvider provider) => Provider = provider;
        IServiceProvider Provider { get; }

        public async Task<BillingId> RegisterAsync(CreditCard card) =>
            await Adapter().RegisterAsync(card);

        public async Task ChargeAsync(BillingId id, decimal amount) =>
            await Adapter(id).ChargeAsync(id, amount); 

        IPaymentAdapter Adapter() => Adapter(typeof(IMainPaymentAdapter));
        IPaymentAdapter Adapter(BillingId id) => Adapter(id.Adapter);
        IPaymentAdapter Adapter(Type type) => 
            (IPaymentAdapter)Provider.GetService(type);
    }
}
