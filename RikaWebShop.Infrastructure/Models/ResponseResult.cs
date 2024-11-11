namespace RikaWebShop.Infrastructure.Models;

public class ResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
public class ResponseResult<T> : ResponseResult
{
    public T? Data { get; set; }
}

