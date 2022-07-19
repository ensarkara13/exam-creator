using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories.Concrete.EntityFramework
{
  public class EFUserRepository : GenericRepository<User>, IUserRepository
  {
    public EFUserRepository(ExamCreatorDbContext context) : base(context)
    {
    }
  }
}