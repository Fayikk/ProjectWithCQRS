using Core.Persistence.Repositoriess;
using Persistence.Context;

public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {

    }
}

