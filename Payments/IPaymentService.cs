using System;
using System.Threading.Tasks;

namespace Payments
{
    public interface IMainPaymentAdapter : IPaymentAdapter
    {
    }

    public interface IPaymentAdapter : IPaymentService
    {
    }

    public interface IPaymentGateway : IPaymentService
    {
    }

    public interface IPaymentService
    {
        Task<BillingId> RegisterAsync(CreditCard card);
        Task ChargeAsync(BillingId id, decimal amount);
    }
}
