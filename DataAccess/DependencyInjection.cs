using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ExamCreatorDbContext>(options => options.UseSqlite(configuration.GetConnectionString("ExamCreatorDB")));

      services.AddScoped<IUserRepository, EFUserRepository>();
      services.AddScoped<IExamRepository, EFExamRepository>();
      services.AddScoped<IUserExamRepository, EFUserExamRepository>();
      services.AddScoped<IQuestionRepository, EFQuestionRepository>();
      services.AddScoped<IQuestionOptionRepository, EFQuestionOptionRepository>();

      return services;
    }
  }
}