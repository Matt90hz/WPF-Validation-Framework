using Validation.Rules.Base;
using System.Linq;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementaion of <see cref="NoSymbolsRule"/> that checks if a <see cref="string"/> contains any symbol.
    /// </summary>
    public class NoSymbolsRule : ExtendedValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            if (((string?)value ?? string.Empty).Any(c => char.IsSymbol(c)))
            {
                return new ValidationResult(false, "No symbols allowed");
            }

            return ValidationResult.ValidResult;
        }

    }

}
