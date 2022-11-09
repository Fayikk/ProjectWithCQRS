using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILanguageRepository : IAsyncRepository<Language>, IRepository<Language>
    {
        //tamamen brand'e özel operasyonlarımız olursa buraya yazacağız.

    }
}
