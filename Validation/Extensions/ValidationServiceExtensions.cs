using Validation.Descriptions.Interfaces;
using System;
using Validation.Interfaces;

namespace Validation.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IValidationService"/>.
    /// </summary>
    public static partial class ValidationServiceExtensions
    {
        /// <summary>
        /// Add a <see cref="IValidationDescriptions{T}"/> to <see cref="ValidationService"/>. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationService"></param>
        /// <returns>
        /// <see cref="IValidationService"/> to chain the construction.
        /// </returns>
        /// <exception cref="Exception"></exception>
        /// <remarks>
        /// Because is not possible to set an unbounded genric type as constraint for a generic type parameter,
        /// the compiler let the use of <see cref="IValidationDescriptions"/> implementations
        /// instead of <see cref="IValidationDescriptions{T}"/>.
        /// <para>
        /// An exception is thrown if <c>T</c> do not implement <see cref="IValidationDescriptions{T}"/>.
        /// </para>
        /// </remarks>
        public static IValidationService AddValidationDescription<T>(this IValidationService validationService) where T : IValidationDescriptions, new()
        {
            try
            {
                validationService.AddValidationDescription((dynamic)new T());
            }
            catch (Exception ex)
            {
                throw new Exception($"Watch out the generic type T must implement {nameof(IValidationDescriptions)}<> generic type. " +
                    $"Is not explicitly required because is not possible set constraints for unbounded generic types.", ex);
            }

            return validationService;
        }

        /// <summary>
        /// Add a <see cref="IValidationDescriptions{T}"/> to the <see cref="IValidationService"/>.
        /// </summary>
        /// <param name="validationService"></param>
        /// <param name="type">The type of the <see cref="IValidationDescriptions{T}"/> to add.</param>
        /// <returns>
        /// <see cref="IValidationService"/> to chain the construction.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws an exception if the the <paramref name="type"/> is not an implementation of <see cref="IValidationDescriptions{T}"/> or do not have a parameterless constructor.
        /// </exception>
        /// <remarks>
        /// The <paramref name="type"/> must implement <see cref="IValidationDescriptions{T}"/> and have a parameterless constructor.
        /// </remarks>
        public static IValidationService AddValidationDescription(this IValidationService validationService, Type type)
        {
            try
            {
                validationService.AddValidationDescription((dynamic)Activator.CreateInstance(type)!);
            }
            catch (Exception ex)
            {
                throw new Exception($"Watch out the type parameter must implement {nameof(IValidationDescriptions)}<> generic type.", ex);
            }

            return validationService;
        }
    }
}
