using Core.Models;
using Core.Extensions;
using FluentValidation.Results;

namespace Core.Utilities.Results
{
  public struct DataResult<T>
  {
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public List<CustomValidationError> ErrorMessages { get; private set; }
    public T Data { get; private set; }

    public static DataResult<T> Success(T data)
    {
      return new DataResult<T>()
      {
        IsSuccess = true,
        Data = data
      };
    }

    public static DataResult<T> Success(T data, string message)
    {
      return new DataResult<T>()
      {
        IsSuccess = true,
        Data = data,
        Message = message
      };
    }

    public static DataResult<T> Failure(string message)
    {
      return new DataResult<T>()
      {
        IsSuccess = false,
        Message = message
      };
    }

    public static DataResult<T> Failure(ValidationResult validationResult)
    {
      return new DataResult<T>()
      {
        IsSuccess = false,
        ErrorMessages = validationResult.ParseToCustomErrors()
      };
    }
  }
}