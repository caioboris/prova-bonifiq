using ProvaPub.Models;
using ProvaPub.Services.Providers.Payment.Interfaces;

namespace ProvaPub.Services.Providers.Payment
{
    public class PayPalPaymentProvider : IPaymentProvider
    {
        public async Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            //Faz pagamento via paypal ...
            return await Task.FromResult(new Order() { Value = paymentValue });
        }
    }
}
