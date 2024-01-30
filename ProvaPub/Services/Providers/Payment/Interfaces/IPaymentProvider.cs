using ProvaPub.Models;

namespace ProvaPub.Services.Providers.Payment.Interfaces
{
    public interface IPaymentProvider
    {
        Task<Order> PayOrder(decimal paymentValue, int customerId);
    }
}
