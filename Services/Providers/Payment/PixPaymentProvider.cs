using ProvaPub.Models;
using ProvaPub.Services.Providers.Payment.Interfaces;

namespace ProvaPub.Services.Providers.Payment
{
    public class PixPaymentProvider : IPaymentProvider
    {
        public async Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            //Faz pagamento via pix ...
            return await Task.FromResult(new Order() { Value = paymentValue });
        }
    }
}
