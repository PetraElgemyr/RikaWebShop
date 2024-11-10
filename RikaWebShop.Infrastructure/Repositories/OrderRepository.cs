using RikaWebShop.Infrastructure.Interfaces;

namespace RikaWebShop.Infrastructure.Repositories;

public class OrderRepository<T> : BaseRepository<T>, IOrderRepository<T>
{
}
