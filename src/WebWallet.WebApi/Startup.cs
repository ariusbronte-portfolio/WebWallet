using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebWallet.DataAccess;
using WebWallet.DataAccess.Extensions;

namespace WebWallet.WebApi
{
    /// <summary>
    ///      Configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {
        /// <inheritdoc cref="Microsoft.Extensions.Configuration.IConfiguration"/>
        private readonly IConfiguration _configuration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebWallet.WebApi.Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        ///     Represents a set of key/value application configuration properties.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Defines a contract for a collection of service descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Register database
            var connectionString = _configuration.GetConnectionString("Default");
            var migrationsAssembly = typeof(WebWalletDbContext).Assembly.FullName;
            services.AddDbContext(connectionString, migrationsAssembly);
            
            services.AddControllers();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        ///     Provides the mechanisms to configure an application's request pipeline.
        /// </param>
        /// <param name="env">
        ///     Provides information about the web hosting environment an application is running in.
        /// </param>
        /// <param name="logger">
        ///     Represents a type used to perform logging.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
