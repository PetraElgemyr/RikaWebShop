using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Interfaces;

public interface IOrderService
{
    ResponseResult<Order> Create(OrderRequest orderRequest);
    ResponseResult<IEnumerable<Order>> GetAll();
    ResponseResult<Order> GetOneByOrderNumber(string orderNumber);
    ResponseResult<Order> UpdateOneByOrderNumber(string orderNumber, OrderUpdateRequest updateRequest);
    ResponseResult<Order> DeleteOneByOrderNumber(string orderNumber);

}