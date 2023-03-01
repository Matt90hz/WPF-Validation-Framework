using Validation.Rules.Base;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementation of <see cref="ExtendedValidationRule"/> that evalute if a <see cref="string"/> can be parsed to an <see cref="int"/>.
    /// </summary>
    public class IntegerValuesRule : ExtendedValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            return int.TryParse(value?.ToString(), out _) ? ValidationResult.ValidResult : new ValidationResult(false, "Only integer numbers accepted!");
        }

    }
}
