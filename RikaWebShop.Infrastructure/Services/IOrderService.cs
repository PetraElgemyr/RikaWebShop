using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Services
{
    public interface IOrderService
    {
        ResponseResult<Order> Create(OrderRequest orderRequest);
        ResponseResult DeleteOne(Func<Order, bool> predicate);
        ResponseResult<IEnumerable<Order>> GetAll();
        ResponseResult<Order> GetOne(Func<Order, bool> predicate);
        ResponseResult<Order> UpdateOne(Func<Order, bool> predicate, Order updatedOrder);
    }
}