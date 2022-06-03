using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
      

      services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}