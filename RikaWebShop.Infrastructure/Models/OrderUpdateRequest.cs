using System.ComponentModel.DataAnnotations;

namespace RikaWebShop.Infrastructure.Models;

public class OrderUpdateRequest
{
    [Required(ErrorMessage = "Order number is required!")]
    public string OrderNumber { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid last name")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter an valid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid phone number")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid delivery address")]
    public DeliveryAddress DeliveryAddress { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid total price")]
    public decimal TotalPrice { get; set; }
}
