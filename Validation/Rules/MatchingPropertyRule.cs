using Validation.Rules.Base;
using System;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implemantation of <see cref="ExtendedValidationRule"/> that checks if two properties on the same object
    /// of type <typeparamref name="T"/> has the same values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MatchingPropertyRule<T> : ExtendedValidationRule where T : class
    {
        /// <summary>
        /// Function that reppresent the property that has to be matched.
        /// </summary>
        public Func<T?, object?> Property { get; }

        /// <summary>
        /// Creates a new instance of <see cref="MatchingPropertyRule{T}"/> and initialize <see cref="Property"/> with <paramref name="property"/>.
        /// </summary>
        /// <param name="property"></param>
        public MatchingPropertyRule(Func<T?, object?> property)
        {
            Property = property;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) =>
            value.Equals(Property.Invoke((T)sender)) ?
            ValidationResult.ValidResult : new(false, "Values does not match!");

    }

}
