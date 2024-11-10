using RikaWebShop.Infrastructure.Interfaces;
using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Validators;

public class OrderValidator : IOrderValidator
{
    private readonly IAddressValidator _addressValidator;

    public OrderValidator(IAddressValidator addressValidator)
    {
        _addressValidator = addressValidator;
    }

    public ValidatorResult ValidateOrderRequest(OrderRequest orderRequest)
    {
        if (string.IsNullOrEmpty(orderRequest.TotalPrice.ToString()) && orderRequest.TotalPrice > 0)
        {
            return new ValidatorResult { Success = false, StatusCode = 400, Message = "Total price is required" };
        }

        var deliveryValidationResult = _addressValidator.ValidateDeliveryAddress(orderRequest.DeliveryAddress);

        if (string.IsNullOrEmpty(orderRequest.FirstName)
            || string.IsNullOrEmpty(orderRequest.LastName)
            || string.IsNullOrEmpty(orderRequest.PhoneNumber)
            || string.IsNullOrEmpty(orderRequest.Email) || !deliveryValidationResult.Success
            )
        {
            return new ValidatorResult { Success = false, StatusCode = 400, Message = "The required customer info was not filled out correctly." };
        }

        return new ValidatorResult { Success = true, StatusCode = 200 };
    }
}
