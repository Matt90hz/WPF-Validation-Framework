using Descriptions.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Validation.Interfaces;

namespace Validation
{
    /// <summary>
    /// Concrete implementation of <see cref="IValidationService"/>
    /// </summary>
    internal class ValidationService : IValidationService
    {
        private readonly ICollection<IValidationDescriptions> _validationDescriptions = new List<IValidationDescriptions>();

        /// <inheritdoc/>
        public IValidationService AddValidationDescription<T>(IValidationDescriptions<T> validationDescriptions) where T : class
        {
            _validationDescriptions.Add(validationDescriptions);
            return this;
        }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Results<T>(T target, string propName) where T : class
        {
            if (GetTargetValue(target, propName) is not object targetValue) return Enumerable.Empty<ValidationResult>();

            return _validationDescriptions.FirstOrDefault(vd => typeof(IValidationDescriptions<>).MakeGenericType(target.GetType()).IsInstanceOfType(vd))?
                .GetRules(propName)?.Select(r => r.Validate(targetValue, target)) ?? Enumerable.Empty<ValidationResult>();
        }

        /// <summary>
        /// Get the value of a property names <paramref name="propName"/> in the <paramref name="target"/> object.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propName"></param>
        /// <returns>
        /// The value of the propery or <c>null</c> if the property is not found on <paramref name="target"/>.
        /// </returns>
        private static object? GetTargetValue(object target, string propName) => target.GetType().GetProperty(propName)?.GetValue(target);

    }

}