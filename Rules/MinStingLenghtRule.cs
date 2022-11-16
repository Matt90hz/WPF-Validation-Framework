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
    /// Implementation of <see cref="ExtendedValidationRule"/> that validate if a <see cref="string"/> is longer than <see cref="MinStingLenght"/>
    /// </summary>
    public class MinStingLenghtRule : ExtendedValidationRule
    {
        /// <summary>
        /// Value used by <see cref="Validate(object, object)"/> to calculate <see cref="ValidationResult"/>.
        /// </summary>
        public int MinStingLenght { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="MinStingLenghtRule"/> and initialize <see cref="MinStingLenght"/> to <paramref name="minStingLenght"/>.
        /// </summary>
        /// <param name="minStingLenght"></param>
        public MinStingLenghtRule(int minStingLenght)
        {
            MinStingLenght = minStingLenght;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) => 
            value is string s && s.Length >= MinStingLenght ?
            ValidationResult.ValidResult : new(false, "Too short!");
        
    }
}
