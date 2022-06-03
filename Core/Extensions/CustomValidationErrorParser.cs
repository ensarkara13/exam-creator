using Core.Models;
using FluentValidation.Results;

namespace Core.Extensions
{
  public static class CustomValidationErrorParser
  {
    public static List<CustomValidationError> ParseToCustomErrors(this ValidationResult validationResult)
    {
      List<CustomValidationError> customErrors = new List<CustomValidationError>();

      foreach (ValidationFailure failure in validationResult.Errors)
      {
        customErrors.Add(
          new CustomValidationError()
          {
            PropertyName = failure.PropertyName,
            ErrorMessage = failure.ErrorMessage
          }
        );
      }

      return customErrors;
    }
  }
}