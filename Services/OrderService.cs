using ProvaPub.Models;
using ProvaPub.Models.Enums;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class OrderService : IOrderService
	{
		private readonly PaymentProcessor _processor;

        public OrderService(PaymentProcessor processor)
        {
            _processor = processor;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
            if (!Enum.TryParse<PaymentMethod>(paymentMethod, true, out var parsedPaymentMethod))
            {
                throw new ArgumentException("Método de pagamento inválido", nameof(paymentMethod));
            }

            return await _processor.ProcessPayment(parsedPaymentMethod, paymentValue, customerId);
		}
	}
}
