using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Interfaces
{
    public interface IAddressValidator
    {
        ValidatorResult ValidateDeliveryAddress(DeliveryAddress deliveryAddress);
    }
}