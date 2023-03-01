using Validation.Rules.Base;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementation of <see cref="ExtendedValidationRule"/> that checks if a property value is <c>null</c>.
    /// </summary>
    public class NotNullRule : ExtendedValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            return value is null ? new ValidationResult(false, "Null value!") : new ValidationResult(true, null);
        }
    }

}
