using Validation.Rules.Base;
using System;
using System.Net.Mail;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// Implementation of <see cref="ExtendedValidationRule"/> that evaluate if a <see cref="string"/> is an email format.
    /// </summary>
    public class EmailFormatRule : ExtendedValidationRule
    {
        public override ValidationResult Validate(object value, object sender)
        {
            try
            {
                var m = new MailAddress((string)value);
                return ValidationResult.ValidResult;
            }
            catch (FormatException ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return new ValidationResult(false, ex.Message);
            }
        }

    }

}
