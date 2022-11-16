using System.Globalization;
using System.Windows.Controls;

namespace Rules.Base
{
    /// <summary>
    /// Base class that extends <see cref="ValidationRule"/> with <see cref="Validate(object, object)"/> function.
    /// </summary>
    /// <remarks>The added <see cref="Validate(object, object)"/> method let create cross reaference property validation.</remarks>
    public abstract class ExtendedValidationRule : ValidationRule
    {
        /// <summary>
        /// Validates the <paramref name="value"/> of the <paramref name="sender"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sender"></param>
        /// <returns>
        /// <see cref="ValidationResult.ValidResult"/> if validation succed.
        /// <para>
        /// <see cref="ValidationResult"/> with <see cref="ValidationResult.IsValid"/> set to <c>false</c> if validation fails.
        /// </para>
        /// </returns>
        public abstract ValidationResult Validate(object value, object sender);

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return Validate(value, this);
        }
    }
}
