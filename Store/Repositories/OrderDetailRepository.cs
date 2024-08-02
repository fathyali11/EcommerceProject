
using WebStore.Models;

namespace WebStore.Repositories
{
	public class OrderDetailRepository : IOrderDetailRepository
	{
		private readonly ApplicationDbContext context;

		public OrderDetailRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public OrderDetail? Add(OrderDetail orderDetail)
		{
			if (orderDetail == null)
				return null;
			context.OrderDetails.Add(orderDetail);
			var NumberOfUpdates = context.SaveChanges();
			if (NumberOfUpdates > 0)
				return orderDetail;
			return null;
		}

		public IEnumerable<OrderDetail> GetAll()
		{
			return context.OrderDetails.Include(x=>x.OrderHeader).Include(x=>x.Product).ToList();
		}

		public OrderDetail GetBy(int id)
		{
			return context.OrderDetails.Include(x=>x.OrderHeader).Include(x=>x.Product).FirstOrDefault();
		}

		public OrderDetail? Remove(OrderDetail orderDetail)
		{
			if (orderDetail == null)
				return null;
			context.OrderDetails.Remove(orderDetail);
			var NumberOfUpdates = context.SaveChanges();
			if (NumberOfUpdates > 0)
				return orderDetail;
			return null;
		}

		public OrderDetail? Update(OrderDetail orderDetail, int id)
		{
			var OldOrderDetail=GetBy(id);
			OldOrderDetail.Price = orderDetail.Price;
			OldOrderDetail.Product = orderDetail.Product;
			OldOrderDetail.OrderHeader = orderDetail.OrderHeader;
			OldOrderDetail.Count = orderDetail.Count;
			var NumberOfUpdates = context.SaveChanges();
			if (NumberOfUpdates > 0)
				return orderDetail;
			return null;
		}
	}
}
