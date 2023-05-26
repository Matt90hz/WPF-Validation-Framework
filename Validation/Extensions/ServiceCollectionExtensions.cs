using Validation.Descriptions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Validation.Interfaces;
using System.Reflection;

namespace Validation.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a singleton service of the type <see cref="IValidationService"/> with <see cref="ValidationService"/> instance implementation.
        /// <para>
        /// Use <paramref name="loadDescriptions"/> to register <see cref="IValidationDescriptions{T}"/> in the <see cref="IValidationService"/>.
        /// </para>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="loadDescriptions"></param>
        /// <returns>A refernce to <see cref="IServiceCollection"/> after the operation are finished.</returns>
        /// <remarks>
        /// The <see cref="IValidationService"/> is singleton by design and can be accessed also via the static class <see cref="Validator"/>.
        /// </remarks>
        public static IServiceCollection AddValidation(this IServiceCollection services, Action<IValidationService>? loadDescriptions = null)
        {
            loadDescriptions?.Invoke(Validator.ValidationService);
            services.AddSingleton(Validator.ValidationService);
            return services;
        }

        /// <summary>
        /// Registers all the <see cref="IValidationDescriptions{T}"/> implementations containd in the <paramref name="assembly"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="assembly">The assembly that contains the <see cref="IValidationDescriptions{T}"/> implementations to register.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// /// <remarks>
        /// The <see cref="IValidationService"/> is singleton by design and can be accessed also via the static class <see cref="Validator"/>.
        /// </remarks>
        public static IServiceCollection RegisterValidation(this IServiceCollection services, Assembly assembly)
        {
            services.AddSingleton(Validator.ValidationService);

            foreach(var type in assembly.GetTypes())
            {
                if (type.GetInterface(typeof(IValidationDescriptions<>).Name) is null) continue;

                Validator.ValidationService.AddValidationDescription(type);
            }

            return services;
        }

    }
}
