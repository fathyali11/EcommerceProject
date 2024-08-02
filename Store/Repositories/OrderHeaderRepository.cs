
namespace WebStore.Repositories
{
	public class OrderHeaderRepository : IOrderHeaderRepository
	{
		private readonly ApplicationDbContext context;

		public OrderHeaderRepository(ApplicationDbContext context)
        {
			this.context = context;
		}
        public OrderHeader? Add(OrderHeader orderHeader)
		{
			if(orderHeader == null)
				return null;
			context.OrderHeaders.Add(orderHeader);
			var NumberOfUpdates=context.SaveChanges();
			if(NumberOfUpdates > 0) 
				return orderHeader;
			return null;
		}

		public IEnumerable<OrderHeader> GetAll()
		{
			return context.OrderHeaders.Include(x=>x.ApplicationUser).ToList();
				
		}

		public OrderHeader GetBy(int id)
		{
			return context.OrderHeaders.FirstOrDefault(x => x.Id == id);
		}

		public OrderHeader? Remove(OrderHeader orderHeader)
		{
			if (orderHeader == null)
				return null;
			context.OrderHeaders.Remove(orderHeader);
			var NumberOfUpdates = context.SaveChanges();
			if (NumberOfUpdates > 0)
				return orderHeader;
			return null;
		}

		public OrderHeader? Update(OrderHeader orderHeader, int id)
		{
			var OldOrderHeader=GetBy(id);

			OldOrderHeader.Name = orderHeader.Name;
			OldOrderHeader.PhoneNumber = orderHeader.PhoneNumber;
			OldOrderHeader.StreetAddress = orderHeader.StreetAddress;
			OldOrderHeader.City = orderHeader.City;
			OldOrderHeader.State = orderHeader.State;
			OldOrderHeader.PostalCode = orderHeader.PostalCode;

			var NumberOfUpdates = context.SaveChanges();
			if (NumberOfUpdates > 0)
				return orderHeader;
			return null;
		}

		public void UpdateStatus(int id, string OrderStatus, string PaymentStatus = null)
		{
			var orderFromDB=GetBy(id);
			orderFromDB.OrderStatus=OrderStatus;
			if(!string.IsNullOrEmpty(PaymentStatus))
				orderFromDB.PaymentStatus=PaymentStatus;

			context.SaveChanges();
		}

		public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
		{
			var orderFromDB=GetBy(id);
			orderFromDB.SessionId=sessionId;
			orderFromDB.PaymentIntentId=paymentIntentId;
			orderFromDB.PaymentDate=DateTime.Now;
			context.SaveChanges();
		}
	}
}
