using ProvaPub.Models;
using ProvaPub.Models.Enums;
using ProvaPub.Services.Providers.Payment;
using ProvaPub.Services.Providers.Payment.Interfaces;

namespace ProvaPub.Services
{
    public class PaymentProcessor
    {
        private readonly Dictionary<PaymentMethod, IPaymentProvider> _paymentProviders;

        public PaymentProcessor()
        {
            _paymentProviders = new Dictionary<PaymentMethod, IPaymentProvider>
            {
                { PaymentMethod.Pix, new PixPaymentProvider() },
                { PaymentMethod.CreditCard, new CreditCardPaymentProvider() },
                { PaymentMethod.PayPal, new PayPalPaymentProvider() },
                //Caso necessário precisamos apenas adicionar o novo método nesse dicionário e criar a regra de implementação em um novo objeto que implemente IPaymentProvider
            };
        }

        public async Task<Order> ProcessPayment(PaymentMethod paymentMethod, decimal paymentValue, int customerId)
        {
            if(_paymentProviders.TryGetValue(paymentMethod, out var paymentProvider))
            {
                return await paymentProvider.PayOrder(paymentValue, customerId);
            }
            else
            {
                throw new ArgumentException("Método de pagamento não suportado", nameof(paymentMethod));
            }
        }

    }
}
