using RikaWebShop.Infrastructure.Interfaces;
using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Validators;

public class AddressValidator : IAddressValidator
{
    public ValidatorResult ValidateDeliveryAddress(DeliveryAddress deliveryAddress)
    {
        if (string.IsNullOrEmpty(deliveryAddress.City)
          || string.IsNullOrEmpty(deliveryAddress.StreetName)
          || string.IsNullOrEmpty(deliveryAddress.StreetName)
          || string.IsNullOrEmpty(deliveryAddress.StreetNumber)
          || string.IsNullOrEmpty(deliveryAddress.ZipCode)
          )
        {
            return new ValidatorResult { Success = false, StatusCode = 400, Message = "The delivery address was not provided correctly." };
        }

        return new ValidatorResult { Success = true, StatusCode = 200 };
    }
}
