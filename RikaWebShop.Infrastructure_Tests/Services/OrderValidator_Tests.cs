using Moq;
using RikaWebShop.Infrastructure.Interfaces;
using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure_Tests.Services;

public class OrderValidator_Tests
{

    private readonly Mock<IOrderValidator> _mockOrderValidator;
    private readonly IOrderValidator _orderValidator;


    public OrderValidator_Tests()
    {
        _mockOrderValidator = new Mock<IOrderValidator>();
        _orderValidator = _mockOrderValidator.Object;
    }

    [Fact]
    public void Validate_ShouldReturnValidationFailed_WhenOrderIsMissingInformation()
    {
        var request = new OrderRequest
        {
            TotalPrice = 1050,
            LastName = "Tomtefar",
            PhoneNumber = "",
            DeliveryAddress = new DeliveryAddress
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetNumber = "1",
                ZipCode = "00000"
            }
        };

        var expectedResult = new ValidatorResult { Success = false, StatusCode = 400 };
        _mockOrderValidator.Setup(x => x.ValidateOrderRequest(request)).Returns(expectedResult);
        var result = _orderValidator.ValidateOrderRequest(request);

        Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        Assert.False(result.Success);
    }
}