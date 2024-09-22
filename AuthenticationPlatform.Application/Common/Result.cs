using System.Net;

namespace AuthenticationPlatform.Application.Common;
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T Value { get; private set; }
    public string ErrorMessage { get; private set; }

    public HttpStatusCode StatusCode { get; private set; }

    private Result(bool isSuccess, T value, string errorMessage, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public static Result<T> Success(T value) => new Result<T>(true, value, null);
    public static Result<T> Failure(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new Result<T>(false, default, errorMessage, statusCode);
}
