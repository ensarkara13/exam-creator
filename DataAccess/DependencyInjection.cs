using DataAccess.Contexts;
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

      services.AddIdentityCore<User>(option =>
      {
        option.Password.RequiredLength = 8;
        option.Password.RequireDigit = true;
        option.Password.RequireLowercase = true;
        option.Password.RequireUppercase = true;

        option.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<ExamCreatorDbContext>();

      return services;
    }
  }
}