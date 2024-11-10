using System.Net;

namespace RikaWebShop.Infrastructure.Models;

public class Order
{
    public string OrderNumber { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DeliveryAddress DeliveryAddress { get; set; } = null!;
    public decimal TotalPrice { get; set; }
}
