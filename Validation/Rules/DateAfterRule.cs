using Validation.Rules.Base;
using System;
using System.Windows.Controls;

namespace Validation.Rules
{
    /// <summary>
    /// <see cref="ExceptionValidationRule"/> implamentation that checks if a <see cref="DateTime"/> property come after <see cref="After"/>.
    /// </summary>
    public class DateAfterRule : ExtendedValidationRule
    {
        private readonly DateTime? _after;
        private readonly Func<DateTime>? _afterFunc;

        /// <summary>
        /// Value used by <see cref="Validate(object, object)"/> to assess <see cref="ValidationResult"/>.
        /// </summary>
        public DateTime After => _after is DateTime date ? date : _afterFunc!.Invoke();

        /// <summary>
        /// Create a new instance of <see cref="DateAfterRule"/> with <see cref="After"/> set to <paramref name="after"/>.
        /// </summary>
        /// <param name="after"></param>
        public DateAfterRule(DateTime after)
        {
            _after = after;
        }

        /// <summary>
        /// Create a new instance of <see cref="DateAfterRule"/>. The <see cref="After"/> 
        /// value will be evaluated each time that <see cref="Validate(object, object)"/>
        /// is called by invoking the function <paramref name="after"/>.
        /// </summary>
        /// <param name="after"></param>
        public DateAfterRule(Func<DateTime> after)
        {
            _afterFunc = after;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) =>
            value is DateTime date && date > After ?
            ValidationResult.ValidResult : new ValidationResult(false, "Date before the limit!");
    }

    /// <summary>
    /// Check if a <see cref="DateTime"/> property of the type <typeparamref name="T"/> come after an other <see cref="DateTime"/>
    /// property of the same object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DateAfterRule<T> : ExtendedValidationRule where T : class
    {
        /// <summary>
        /// A function that rappresent the <see cref="DateTime"/> property that is used by <see cref="Validate(object, object)"/> to evaluate
        /// <see cref="ValidationResult"/>.
        /// </summary>
        public Func<T, DateTime?> Property { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DateAfterRule{T}"/> and initialize <see cref="Property"/> with <paramref name="property"/>.
        /// </summary>
        /// <param name="property"></param>
        public DateAfterRule(Func<T, DateTime?> property)
        {
            Property = property;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            return value is DateTime date && date > Property.Invoke((T)sender) ?
                ValidationResult.ValidResult :
                new(false, "Date before the limit!");
        }

    }

}
