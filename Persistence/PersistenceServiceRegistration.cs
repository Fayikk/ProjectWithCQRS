using Application.Services;
using Application.Services.AuthService;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                        IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("SoftwareCoursesConnectionString")));
            services.AddScoped<ILanguageRepository, LanguageRepository>();//Enjeksiyon işlemini burada gerçekleştiriyoruz.
            services.AddScoped<ILanguageTecnologyRepository, LanguageTechnologyRepository>();//Enjeksiyon işlemini burada gerçekleştiriyoruz.
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IGithubRepository, GithubRepository>();
            //Yani birisi sende IBrandRepository verirse sen ona Brand Repository ver anlamına gelmektedir.
            return services;
        }
    }
}
