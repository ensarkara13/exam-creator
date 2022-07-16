using System.Reflection;
using Business.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
      services.AddScoped<IExamService, ExamManager>();
      services.AddScoped<IQuestionService, QuestionManager>();
      services.AddScoped<IQuestionOptionService, QuestionOptionManager>();

      services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}