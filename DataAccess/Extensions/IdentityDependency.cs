using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions
{
  public static class IdentityDependency
  {
    public static IdentityBuilder AddIdentity<TUser, TRole>(this IServiceCollection services, Action<IdentityOptions> options)
    {
      return new IdentityBuilder(typeof(TUser), typeof(TRole), services);
    }
  }
}