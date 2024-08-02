namespace WebStore.IRepositories
{
	public interface IOrderDetailRepository
	{
		IEnumerable<OrderDetail> GetAll();
		OrderDetail GetBy(int id);
		OrderDetail ?Add(OrderDetail orderDetail);
		OrderDetail ?Update(OrderDetail orderDetail,int id);
		OrderDetail ?Remove(OrderDetail orderDetail);
	}
}
