using Application.Services;
using Core.Persistence.Repositoriess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LanguageRepository : EfRepositoryBase<Language , BaseDbContext>,ILanguageRepository
    {
        public LanguageRepository(BaseDbContext context) : base(context)
        {

        }
    }
}

