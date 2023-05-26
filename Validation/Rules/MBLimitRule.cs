using Validation.Rules.Base;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementation of <see cref="ExtendedValidationRule"/> that check if a <see cref="byte[]"/> is within the <see cref="Limit"/> in MB.
    /// </summary>
    /// <remarks>
    /// This rule has been created to validate an image converted to byte array that had to be saved on a database.
    /// </remarks>
    public sealed class MBLimitRule : ExtendedValidationRule
    {
        private long _limit;

        /// <summary>
        /// Maximum number of MB that the validated value can have.
        /// </summary>
        public int Limit { get => (int)(_limit / 1e+6); set => _limit = (long)(value * 1e+6); }

        /// <summary>
        /// Create a new instance of <see cref="MBLimitRule"/> and initialize <see cref="Limit"/> to 50 MB.
        /// </summary>
        public MBLimitRule()
        {
            Limit = 50;
        }

        /// <summary>
        /// Create a new instance of <see cref="MBLimitRule"/> and initialize <see cref="Limit"/> to <paramref name="limit"/> MB.
        /// </summary>
        /// <param name="limit"></param>
        public MBLimitRule(int limit)
        {
            Limit = limit;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            var mb = value as byte[];

            if ((mb?.Length ?? _limit + 1) > _limit)
            {
                return new ValidationResult(
                    false,
                    $"Must be less than {Limit} MB!");
            }

            return new ValidationResult(true, null);
        }
    }
}
