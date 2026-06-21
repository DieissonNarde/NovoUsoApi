using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovoUsoApi.Data;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Repositories;
using NovoUsoApi.Services;
using NovoUsoApi.Services.Interfaces;

namespace NovoUsoApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemPhotoRepository, ItemPhotoRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IItemAgreementRepository, ItemAgreementRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemPhotoService, ItemPhotoService>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IItemAgreementService, ItemAgreementService>();
            
            return services;
        }
    }
}