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

    public ResponseResult<Order> GetOne(Func<Order, bool> predicate)
    {
        try
        {
            //Func<OrderEntity, bool> entityPredicate = entity => predicate(OrderFactory.Create(entity));

            // TODO kolla upp fel
            var result = _orderRepository.GetOne(predicate);
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
        catch
        {
            return ResponseFactory<Order>.Failed(null!);
        }
    }

    public ResponseResult<Order> UpdateOne(Func<Order, bool> predicate, Order updatedOrder)
    {
        // TODO kolla upp fel

        var result = _orderRepository.UpdateOne(predicate, updatedOrder);

        if (result.Success)
        {
            return ResponseFactory<Order>.Success(result.Data!);
        }

        return ResponseFactory<Order>.Failed(result.Data!);
    }


    public ResponseResult DeleteOne(Func<Order, bool> predicate)
    {
        // TODO kolla upp fel

        var result = _orderRepository.DeleteOne(predicate);

        if (result.Success)
        {
            return ResponseFactory<Order>.Success(result.Data!);
        }

        return ResponseFactory<Order>.Failed(result.Data!);
    }

}
