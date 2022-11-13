using Core.Persistence.Repositoriess;
using Core.Security.Entities;
using Persistence.Context;

public class OperationClaimRepository : EfRepositoryBase<OperationClaims, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {

    }
}

