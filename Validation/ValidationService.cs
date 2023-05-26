using Validation.Descriptions.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Validation.Interfaces;
using Validation.Rules.Base;
using System;
using Validation.Descriptions.Extensions;

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

            var validationDescriptionType = typeof(IValidationDescriptions<>).MakeGenericType(target.GetType());
            var validationDescriptions = _validationDescriptions.Where(vd => vd.GetType().IsAssignableTo(validationDescriptionType));
            var rules = validationDescriptions.SelectMany(vd => vd.GetRules(propName) ?? Enumerable.Empty<ExtendedValidationRule>());
            return rules.Select(r => r.Validate(targetValue, target));
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