using Moq;
using RikaWebShop.Infrastructure.Factories;
using RikaWebShop.Infrastructure.Interfaces;
using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure_Tests.Services;



public class OrderSerivce_Tests
{
    private readonly Mock<IOrderService> _mockOrderService;
    private readonly IOrderService _orderService;
   

    public OrderSerivce_Tests()
    {
        _mockOrderService = new Mock<IOrderService>();
        _orderService = _mockOrderService.Object;
    }
    private Order _order = new Order
    {
        OrderNumber = "123",
        TotalPrice = 1050,
        FirstName = "Tomten",
        LastName = "Tomtefar",
        Email = "tomten@domain.com",
        PhoneNumber = "1234567890",
        DeliveryAddress = new DeliveryAddress
        {
            City = "Nordpolen",
            Country = "Nordpolen",
            StreetName = "Nordpolen",
            StreetNumber = "1",
            ZipCode = "00000"
        }
    };

    [Fact]
    public void Create_ShouldReturnSuccess_WhenOrderIsCreated()
    {
        var request = new OrderRequest
        {
            TotalPrice = 1050,
            FirstName = "Tomten",
            LastName = "Tomtefar",
            Email = "tomten@domain.com",
            PhoneNumber = "1234567890",
            DeliveryAddress = new DeliveryAddress
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetName = "Nordpolen",
                StreetNumber = "1",
                ZipCode = "00000"
            }
        };


        var expectedResult = new ResponseResult<Order> { Success = true, StatusCode = 200 };
        _mockOrderService.Setup(x => x.Create(request)).Returns(expectedResult);

        var result = _orderService.Create(request);

        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Success);
    }


    [Fact]
    public void GetAll_ShouldReturnTrueWithData_WhenSuccessIsTrue()
    {


        var orders = new List<Order> { _order };

        var expectedResult = new ResponseResult<IEnumerable<Order>> { Success = true, StatusCode = 200, Data = orders };
        _mockOrderService.Setup(x => x.GetAll()).Returns(expectedResult);

        var result = _orderService.GetAll();

        Assert.True(result.Success);

        Assert.Equal(expectedResult.StatusCode, result.StatusCode);
        Assert.Equal(expectedResult.Data, result.Data);
    }

    [Fact]
    public void GetOneByOrderNumber_ShouldReturnOneOrder_WhenSuccessIsTrue()
    {
        var orders = new List<Order>() { _order };

        var expectedResult = new ResponseResult<Order> { Success = true, StatusCode = 200, Data = _order };
        _mockOrderService.Setup(x => x.GetOneByOrderNumber(_order.OrderNumber)).Returns(expectedResult);

        var result = _orderService.GetOneByOrderNumber(_order.OrderNumber);

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(_order, result.Data);
    }

    [Fact]
    public void UpdateOneByOrderNumber_ShouldReturnSuccessTrue_WithUpdatedOrder()
    {
        var orders = new List<Order> { _order };
        var updateOrderRequest = new OrderUpdateRequest
        {
            OrderNumber = "123",
            TotalPrice = 900,
            FirstName = "Nisse",
            LastName = "Tomtenisse",
            Email = "Nissen@domain.com",
            PhoneNumber = "9999999",
            DeliveryAddress = new DeliveryAddress
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetName = "Nordpolsvägen",
                StreetNumber = "33",
                ZipCode = "111111"
            }
        };

        var updatedOrder = new Order
        {
            OrderNumber = "123",
            TotalPrice = 900,
            FirstName = "Nisse",
            LastName = "Tomtenisse",
            Email = "Nissen@domain.com",
            PhoneNumber = "9999999",
            DeliveryAddress = new DeliveryAddress
            {
                City = "Nordpolen",
                Country = "Nordpolen",
                StreetName = "Nordpolsvägen",
                StreetNumber = "33",
                ZipCode = "111111"
            }
        };


        var expectedResult = new ResponseResult<Order> { Success = true, StatusCode = 200, Data = updatedOrder };
        _mockOrderService.Setup(x => x.UpdateOneByOrderNumber(updateOrderRequest.OrderNumber, updateOrderRequest)).Returns(expectedResult);  
   
        var result = _orderService.UpdateOneByOrderNumber(updateOrderRequest.OrderNumber, updateOrderRequest);
        
        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(updatedOrder, result.Data);
    }

    [Fact]
    public void DeleteOneByOrderNumber_ShouldReturnSuccessTrue_WhenOrderIsDeleted()
    {
        var orders = new List<Order> { _order };
        var expectedResponse = new ResponseResult<Order> { Success = true, StatusCode = 200 };

        _mockOrderService.Setup(x => x.DeleteOneByOrderNumber(_order.OrderNumber)).Returns(expectedResponse);
        var result = _orderService.DeleteOneByOrderNumber(_order.OrderNumber);

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<ResponseResult<Order>>(result);
    }
}



