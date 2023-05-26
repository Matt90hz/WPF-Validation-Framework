using Example.ValidationDescriptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Validation.Extensions;

namespace Example
{
    internal static class ValidationRegistrations
    {
        /// <summary>
        /// Used in the App.cs to register the validation (just to make the example more readable).
        /// </summary>
        public static void RegisterValidation() 
        {
            RegisterValidationWithoutDependencyInjection();
        }

        /// <summary>
        /// Is better use dependency injection and register the validation service and the descriptions but for the example we will use Validator static class.
        /// </summary>
        private static void RegisterValidationWithoutDependencyInjection()
        {
            Validator.ValidationService.AddValidationDescription(new BookValidationDescription());
        }

        /// <summary>
        /// Manually registration.
        /// </summary>
        private static void RegisterValidationWithDependencyInjection(IServiceCollection services)
        {
            services.AddValidation(validationService =>
            {
                validationService.AddValidationDescription<BookValidationDescription>();

                //in case your validation description has constructor parameters
                validationService.AddValidationDescription(new BookValidationDescription(/*object param*/));
            });
        }

        /// <summary>
        /// Automatic registration.
        /// </summary>
        private static void RegisterValidationWithDependencyInjectionAutomatically(IServiceCollection services)
        {
            services.RegisterValidation(typeof(App).Assembly);
        }
    }
}
