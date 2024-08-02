namespace WebStore.IRepositories
{
	public interface IOrderHeaderRepository
	{
		IEnumerable<OrderHeader> GetAll();
		OrderHeader GetBy(int id);
		OrderHeader ?Add(OrderHeader orderHeader);
		OrderHeader ?Update(OrderHeader orderHeader,int id);
		OrderHeader ?Remove(OrderHeader orderHeader);
		void UpdateStatus(int id,string OrderStatus,string PaymentStatus=null);
		void UpdateStripePaymentId(int id,string sessionId,string paymentIntentId);
	}
}
