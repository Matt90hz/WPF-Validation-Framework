using Rules.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rules
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
