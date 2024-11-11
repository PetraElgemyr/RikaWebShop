using RikaWebShop.Infrastructure.Factories;
using RikaWebShop.Infrastructure.Interfaces;
using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Services;

public class OrderService : IOrderService
{

    private readonly IOrderRepository<OrderEntity> _orderRepository;
    private readonly IOrderValidator _orderValidator;

    public OrderService(IOrderRepository<OrderEntity> orderRepository, IOrderValidator orderValidator)
    {
        _orderRepository = orderRepository;
        _orderValidator = orderValidator;
    }

    public ResponseResult<Order> Create(OrderRequest orderRequest)
    {
        try
        {
            var validationResult = _orderValidator.ValidateOrderRequest(orderRequest);
            if (validationResult.Success)
            {
                var entity = OrderFactory.Create(orderRequest);
                var result = _orderRepository.Create(entity);

                if (result.Success)
                {
                    var order = OrderFactory.Create(result.Data!);
                    return ResponseFactory<Order>.Success(order);
                }
            }
            return ResponseFactory<Order>.Failed(null!);
        }
        catch { }
        return ResponseFactory<Order>.Failed(null!);

    }

    public ResponseResult<IEnumerable<Order>> GetAll()
    {
        try
        {
            var result = _orderRepository.GetAll();
            if (result.Success)
            {
                var orders = OrderFactory.Create(result.Data!);
                return ResponseFactory<IEnumerable<Order>>.Success(orders);
            }
            return ResponseFactory<IEnumerable<Order>>.Failed(null!);
        }
        catch { }
        return ResponseFactory<IEnumerable<Order>>.Failed(null!);

    }

    public ResponseResult<Order> GetOneByOrderNumber(string orderNumber)
    {
        try
        {
            var result = _orderRepository.GetOne(x => x.OrderNumber == orderNumber);
            if (result.Success)
            {
                var order = OrderFactory.Create(result.Data!);
                return ResponseFactory<Order>.Success(order);
            }
            else
            {
                return ResponseFactory<Order>.NotFound(null!);
            }
        }
        catch { }
        return ResponseFactory<Order>.Failed(null!);

    }

    public ResponseResult<Order> UpdateOneByOrderNumber(string orderNumber, OrderUpdateRequest updateRequest)
    {

        try
        {
            var entity = OrderFactory.Create(updateRequest);
            var result = _orderRepository.UpdateOne(x => x.OrderNumber == orderNumber, entity);
            var order = OrderFactory.Create(result.Data!);

            if (result.Success)
            {
                return ResponseFactory<Order>.Success(order);
            }
            return ResponseFactory<Order>.Failed(order);

        }
        catch
        { }
        return ResponseFactory<Order>.Failed(null!);

    }


    public ResponseResult<Order> DeleteOneByOrderNumber(string orderNumber)
    {
        try
        {
            var result = _orderRepository.DeleteOne(x => x.OrderNumber == orderNumber);

            if (result.Success)
            {
                var order = OrderFactory.Create(result.Data!);
                return ResponseFactory<Order>.Success(order);
            }

            return ResponseFactory<Order>.Failed(null!);
        }
        catch { }
        return ResponseFactory<Order>.Failed(null!);
    }

}
