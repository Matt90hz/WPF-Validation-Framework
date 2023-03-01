using Validation.Descriptions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Validation.Interfaces;

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
        /// <param name="services"></param>
        /// <param name="loadDescriptions"></param>
        /// <returns>A refernce to <see cref="IServiceCollection"/> after the operation are finished.</returns>
        public static IServiceCollection AddValidation(this IServiceCollection services, Action<IValidationService>? loadDescriptions = null)
        {
            var validationService = new ValidationService();
            loadDescriptions?.Invoke(validationService);
            services.AddSingleton<IValidationService>(validationService);
            return services;
        }
    }
}
