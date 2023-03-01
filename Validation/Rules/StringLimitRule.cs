using Validation.Rules.Base;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementation of <see cref="ExtendedValidationRule"/> that checks if
    /// a <see cref="string"/> property has less characters than <see cref="Limit"/>.
    /// </summary>
    public class StringLimitRule : ExtendedValidationRule
    {
        /// <summary>
        /// Value used by <see cref="Validate(object, object)"/> to assess <see cref="ValidationResult"/>.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="MinStingLenghtRule"/> and initialize <see cref="Limit"/> to 50.
        /// </summary>
        public StringLimitRule()
        {
            Limit = 50;
        }

        /// <summary>
        /// Create a new instance of <see cref="MinStingLenghtRule"/> and initialize <see cref="Limit"/> to <paramref name="limit"/>.
        /// </summary>
        /// <param name="limit"></param>
        public StringLimitRule(int limit)
        {
            Limit = limit;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) =>
            value is string text && text.Length > Limit ?
            new(false, $"Must be less than {Limit} characters!") : ValidationResult.ValidResult;

    }
}
