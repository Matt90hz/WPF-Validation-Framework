using Descriptions.Interfaces;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Validation.Interfaces
{
    /// <summary>
    /// Service to validate property in a WPF Application. 
    /// <para>
    /// Register <see cref="IValidationDescriptions{T}"/> using <see cref="AddValidationDescription{T}(IValidationDescriptions{T})"/>
    /// </para>
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Register an <see cref="IValidationDescriptions{T}"/> in the <see cref="IValidationService"/> implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns></returns>
        IValidationService AddValidationDescription<T>(IValidationDescriptions<T> validationDescriptions) where T : class;
        /// <summary>
        /// Get all the <see cref="ValidationResult"/> for a property of an instance of <typeparamref name="T"/> based on the registered <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="propName"></param>
        /// <returns>
        /// A collection of <see cref="ValidationResult"/>.
        /// <para>
        /// If there are no <see cref="IValidationDescriptions{T}"/> for the <paramref name="target"/>
        /// or the <paramref name="target"/> does not have a property named <paramref name="propName"/>
        /// an empty collection is returned.
        /// </para>
        /// </returns>
        IEnumerable<ValidationResult> Results<T>(T target, string propName) where T : class;
    }




}