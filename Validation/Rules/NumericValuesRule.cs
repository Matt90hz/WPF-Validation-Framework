using Validation.Rules.Base;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementaion of <see cref="ExtendedValidationRule"/> that checks if a <see cref="string"/> can be parsed into a <see cref="int"/>.
    /// </summary>
    public class NumericValuesRule : ExtendedValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) =>
            double.TryParse(value.ToString(), out _) ?
            new ValidationResult(true, null) : new ValidationResult(false, "Only numbers accepted!");
    }
}
