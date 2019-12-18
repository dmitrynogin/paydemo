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
            await Service().RegisterAsync(card);

        public async Task ChargeAsync(BillingId id, decimal amount) =>
            await Service(id).ChargeAsync(id, amount); 

        IPaymentProvider Service() => Service(typeof(IMainPaymentProvider));
        IPaymentProvider Service(BillingId id) => Service(id.Provider);
        IPaymentProvider Service(Type type) => 
            (IPaymentProvider)Provider.GetService(type);
    }
}
