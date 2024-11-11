using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Factories;

public class ResponseFactory<T> : BaseResponseFactory
{
    public static ResponseResult<T> Success(T data, int statusCode = 200, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResult<T> NotFound(T data, int statusCode = 404, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResult<T> Failed(T data, int statusCode = 400, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

   

    public static ResponseResult<T> AlreadyExists(T data, int statusCode = 409, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }
}

