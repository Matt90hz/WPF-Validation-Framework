using Rules.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rules
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
