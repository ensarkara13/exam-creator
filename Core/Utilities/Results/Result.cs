using Core.Models;
using Core.Extensions;
using FluentValidation.Results;

namespace Core.Utilities.Results
{
  public struct Result
  {
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public List<CustomValidationError> ErrorMessages { get; private set; }

    public static Result Success()
    {
      return new Result()
      {
        IsSuccess = true
      };
    }

    public static Result Success(string message)
    {
      return new Result()
      {
        IsSuccess = true,
        Message = message
      };
    }

    public static Result Failure(string message)
    {
      return new Result()
      {
        IsSuccess = false,
        Message = message
      };
    }

    public static Result Failure(ValidationResult validationResult)
    {
      return new Result()
      {
        IsSuccess = false,
        ErrorMessages = validationResult.ParseToCustomErrors()
      };
    }
  }
}