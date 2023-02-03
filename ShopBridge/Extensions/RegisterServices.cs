using System;
using ShopBridge.Dal;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Repository.Contracts;
using ShopBridge.Repository;

namespace ShopBridge
{
	internal static class Register
	{
        public static IServiceCollection RegisterServices(
            this IServiceCollection services, string? connectionString = null)
        {
            services.AddControllers();

            RegisterDependencies(services);

            RegisterSwagger(services);

            if (connectionString != null)
                RegisterDatabase(services, connectionString);
            else
                throw new NullReferenceException("No Connection String was provided");

            return services;
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void RegisterDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ShopBridgeDbContext>(dbOptions =>
            {
                dbOptions.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("ShopBridge")
                        .CommandTimeout(30)
                        .EnableRetryOnFailure())
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Register));

            services.AddScoped<IInventoryRepository, InventoryRepository>();
        }

    }
}

