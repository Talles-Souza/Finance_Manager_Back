using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using InfraData.Repositories;
using Service.Mapping;
using Service.Interfaces;
using Service.Services;
using InfraData.Context;
using Service.Utils;

namespace CrossCutting.Configurantion
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISpendRepository, SpendRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<UserUtils>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(DomainToDTO));
            return services;
        }
    }
}
