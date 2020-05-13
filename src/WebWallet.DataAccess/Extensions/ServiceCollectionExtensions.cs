using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebWallet.DataAccess.Extensions
{
    /// <summary>
    ///     Extension methods for setting up services in an <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Registers the context as a service in the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
        /// </summary>
        /// <example>
        ///     <code>
        ///           public void ConfigureServices(IServiceCollection services)
        ///           {
        ///               var connectionString = "connection string to database";
        ///               var migrationsAssembly = typeof(TContext).Assembly.FullName;
        /// 
        ///               services.AddDbContext(connectionString, migrationsAssembly);
        ///           }
        ///       </code>
        /// </example>
        /// <param name="services">The <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection" /> to add services to.</param>
        /// <param name="connectionString">The connection string of the database to connect to.</param>
        /// <param name="migrationsAssembly">The name of the assembly.</param>
        /// <exception cref="System.ArgumentNullException">
        ///    The services must not be null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///    The connectionString must not be null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///    The migrationsAssembly must not be null.
        /// </exception>
        /// <returns>The <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            string connectionString,
            string migrationsAssembly)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(connectionString));
            if (string.IsNullOrWhiteSpace(migrationsAssembly))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(migrationsAssembly));

            services.AddDbContext<WebWalletDbContext>(options =>
            {
                options.UseNpgsql(connectionString, builder =>
                    builder.MigrationsAssembly(migrationsAssembly));
            });

            return services;
        }
    }
}