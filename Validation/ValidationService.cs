using Validation.Descriptions.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Validation.Interfaces;
using Validation.Rules.Base;

namespace Validation
{
    /// <summary>
    /// Concrete implementation of <see cref="IValidationService"/>
    /// </summary>
    internal class ValidationService : IValidationService
    {
        private readonly ICollection<IValidationDescriptions> _validationDescriptions = new List<IValidationDescriptions>();

        /// <inheritdoc/>
        public IValidationService AddValidationDescription<T>(IValidationDescriptions<T> validationDescription) where T : class
        {
            _validationDescriptions.Add(validationDescription);
            return this;
        }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Results<T>(T target, string propName) where T : class
        {
            if (GetTargetValue(target, propName) is not object targetValue) return Enumerable.Empty<ValidationResult>();

            var validationDescriptions = _validationDescriptions.Where(vd => vd is IValidationDescriptions<T>);
            
            var result = new List<ValidationResult>();

            foreach (var validationDescription in validationDescriptions)
            {
                if (validationDescription.GetRules(propName) is not IEnumerable<ExtendedValidationRule> rules) continue;

                result.AddRange(rules.Select(r => r.Validate(targetValue, target)));
            }

            return result;
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