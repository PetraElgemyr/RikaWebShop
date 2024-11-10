using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Interfaces
{
    public interface IOrderValidator
    {
        ValidatorResult ValidateOrderRequest(OrderRequest orderRequest);
    }
}