using Application.Services;
using Core.Persistence.Repositoriess;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TechnologiesRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologiesRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
