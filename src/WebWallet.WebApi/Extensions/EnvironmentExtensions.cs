using System;
using Microsoft.Extensions.Hosting;

namespace WebWallet.WebApi.Extensions
{
    /// <summary>
    ///     Extension methods for setting up services in an <see cref="Environment" />.
    /// </summary>
    public static partial class Environment
    {
        /// <summary>
        ///     Checks if the current host environment name is <see cref="Microsoft.Extensions.Hosting.EnvironmentName.Development"/>.
        /// </summary>
        /// <returns>True if the environment name is <see cref="Microsoft.Extensions.Hosting.EnvironmentName.Development"/>, otherwise false.</returns>
        public static bool IsDevelopment()
        {
            return IsEnvironment(Environments.Development);
        }

        /// <summary>
        ///     Checks if the current host environment name is <see cref="Microsoft.Extensions.Hosting.EnvironmentName.Staging"/>.
        /// </summary>
        /// <returns>True if the environment name is <see cref="Microsoft.Extensions.Hosting.EnvironmentName.Staging"/>, otherwise false.</returns>
        public static bool IsStaging()
        {
            return IsEnvironment(Environments.Staging);
        }

        /// <summary>
        ///     Checks if the current host environment name is <see cref="Microsoft.Extensions.Hosting.EnvironmentName.Production"/>.
        /// </summary>
        /// <returns>True if the environment name is <see cref="Microsoft.Extensions.Hosting.EnvironmentName.Production"/>, otherwise false.</returns>
        public static bool IsProduction()
        {
            return IsEnvironment(Environments.Production);
        }

        /// <summary>
        ///     Compares the current host environment name against the specified value.
        /// </summary>
        /// <param name="environmentName">Environment name to validate against.</param>
        /// <returns>True if the specified name is the same as the current environment, otherwise false.</returns>
        private static bool IsEnvironment(string environmentName)
        {
            return string.Equals(GetEnvironment(), environmentName, StringComparison.OrdinalIgnoreCase);
        }
    }
    
    /// <summary>
    ///     Extension methods for setting up services in an <see cref="System.Environment" />.
    /// </summary>
    public static partial class Environment
    {
        /// <summary>
        ///     Retrieves the value of an ASPNETCORE_ENVIRONMENT variable from the current process
        /// </summary>
        private static string GetEnvironment()
        {
            return System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }
    }
}