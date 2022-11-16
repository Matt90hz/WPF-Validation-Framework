﻿using Rules.Base;
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
    /// Implementation of <see cref="ExtendedValidationRule"/> that checks if a <see cref="string"/> is <c>null</c> or empty.
    /// </summary>
    public class NoBlankRule : ExtendedValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            string input = value?.ToString() ?? string.Empty;
            return input.Trim().Length > 0 ? ValidationResult.ValidResult : new ValidationResult(false, "Insert value!");
        }

    }

}