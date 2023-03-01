using Validation.Rules.Base;
using System;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementation of <see cref="ExtendedValidationRule"/> that evaluate if a property is equal to <see cref="Value"/>.
    /// </summary>
    public class EqualToRule : ExtendedValidationRule
    {
        private readonly object? _value;
        private readonly Func<object>? _funcValue;

        /// <summary>
        /// Value used by <see cref="Validate(object, object)"/> to evaluate <see cref="ValidationResult"/>.
        /// </summary>
        public object Value => _value is null ? _funcValue! : _value;

        /// <summary>
        /// Create a new instance of <see cref="EqualToRule"/> and set <see cref="Value"/> to <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        public EqualToRule(object value)
        {
            _value = value;
        }

        /// <summary>
        /// Create a new instance of <see cref="EqualToRule"/>. The <paramref name="value"/> function is invoked every time <see cref="Value"/> value is request.
        /// </summary>
        /// <param name="value"></param>
        public EqualToRule(Func<object> value)
        {
            _funcValue = value;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) => value == Value ?
            ValidationResult.ValidResult : new(false, "Different values!");
    }



}
