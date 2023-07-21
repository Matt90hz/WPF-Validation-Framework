using Validation.Descriptions.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Validation.Interfaces;
using Validation.Rules.Base;
using System;
using Validation.Descriptions.Extensions;
using System.Reflection;

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
            if(target.GetType().GetProperty(propName) is not PropertyInfo propInfo) return Enumerable.Empty<ValidationResult>();

            var targetValue = propInfo.GetValue(target);

            var validationDescriptionType = typeof(IValidationDescriptions<>).MakeGenericType(target.GetType());
            var validationDescriptions = _validationDescriptions.Where(vd => vd.GetType().IsAssignableTo(validationDescriptionType));
            var rules = validationDescriptions.SelectMany(vd => vd.GetRules(propName) ?? Enumerable.Empty<ExtendedValidationRule>());
            return rules.Select(r => r.Validate(targetValue, target));
        }

    }

}