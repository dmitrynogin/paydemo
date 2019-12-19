using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.IoC;

namespace Payments
{
    [Service]
    public class PaymentGateway : IPaymentGateway
    {
        public PaymentGateway(IMainPaymentProvider mainProvider, params IPaymentProvider[] providers) => 
            (MainProvider, Providers) = 
            (mainProvider, providers.ToDictionary(p => p.Name));

        IPaymentProvider MainProvider { get; }
        IReadOnlyDictionary<string, IPaymentProvider> Providers { get; }

        public async Task<BillingId> RegisterAsync(CreditCard card) =>
            await MainProvider.RegisterAsync(card);

        public async Task ChargeAsync(BillingId id, decimal amount) =>
            await Providers[id.Provider].ChargeAsync(id, amount); 
    }
}
