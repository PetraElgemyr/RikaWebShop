using System.ComponentModel.DataAnnotations;

namespace RikaWebShop.Infrastructure.Models;

public abstract class BaseAddress
{
    [Required(ErrorMessage = "You must enter a valid street name")]
    public string StreetName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid street number")]
    public string StreetNumber { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid zip code")]
    public string ZipCode { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid city")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid country")]
    public string Country { get; set; } = null!;
}
