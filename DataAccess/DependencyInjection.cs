using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete.EntityFramework;
using Entities.Concrete;
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

      services.AddIdentity<User, Role>(options =>
      {
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;

        options.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<ExamCreatorDbContext>();

      services.AddScoped<IExamRepository, EFExamRepository>();
      services.AddScoped<IUserExamRepository, EFUserExamRepository>();
      services.AddScoped<IQuestionRepository, EFQuestionRepository>();
      services.AddScoped<IQuestionOptionRepository, EFQuestionOptionRepository>();

      return services;
    }
  }
}