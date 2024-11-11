using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Factories;

public static class OrderFactory
{
    public static OrderEntity Create(OrderRequest orderRequest)
    {
		try
		{
			return new OrderEntity
			{
                FirstName = orderRequest.FirstName,
                LastName = orderRequest.LastName,
                Email = orderRequest.Email,
                PhoneNumber = orderRequest.PhoneNumber,
                DeliveryAddress = orderRequest.DeliveryAddress,
                TotalPrice = orderRequest.TotalPrice,
                Created = DateTime.Now
            };
        }
		catch
		{}
		return null!;
    }

    public static Order Create(OrderEntity entity)
    {
        try
        {
            return new Order
            {
                OrderNumber = entity.OrderNumber,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                DeliveryAddress = entity.DeliveryAddress,
                TotalPrice = entity.TotalPrice,
            };
        }
        catch
        { }
        return null!;
    }

    public static OrderEntity Create(OrderUpdateRequest updateOrderRequest)
    {
        try
        {
            return new OrderEntity
            {
                OrderNumber = updateOrderRequest.OrderNumber,
                FirstName = updateOrderRequest.FirstName,
                LastName = updateOrderRequest.LastName,
                Email = updateOrderRequest.Email,
                PhoneNumber = updateOrderRequest.PhoneNumber,
                DeliveryAddress = updateOrderRequest.DeliveryAddress,
                TotalPrice = updateOrderRequest.TotalPrice,
            };
        }
        catch {}
        return null!;
    }

   
    public static IEnumerable<Order> Create(List<OrderEntity> entities)
    {
        var list = new List<Order>();

        try
        {
            foreach (var e in entities)
            {
                list.Add(new Order
                {
                    OrderNumber = e.OrderNumber,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    DeliveryAddress = e.DeliveryAddress,
                    TotalPrice = e.TotalPrice,
                });
            }
        }
        catch
        { }
        return list;
    }
}
