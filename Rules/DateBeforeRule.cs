using Rules.Base;
using System;
using System.Windows.Controls;

namespace Rules
{
    /// <summary>
    /// <see cref="ExceptionValidationRule"/> implamentation that checks if a <see cref="DateTime"/> property come before <see cref="Before"/>.
    /// </summary>
    public class DateBeforeRule : ExtendedValidationRule
    {
        private readonly Func<DateTime>? _beforeFunc;
        private readonly DateTime? _before;

        /// <summary>
        /// Value used by <see cref="Validate(object, object)"/> to assess <see cref="ValidationResult"/>.
        /// </summary>
        public DateTime Before => _before is DateTime date ? date : _beforeFunc!.Invoke();

        /// <summary>
        /// Create a new instance of <see cref="DateAfterRule"/> with <see cref="Before"/> set to <paramref name="before"/>.
        /// </summary>
        /// <param name="before"></param>
        public DateBeforeRule(DateTime before)
        {
            _before = before;
        }

        /// <summary>
        /// Create a new instance of <see cref="DateBeforeRule{T}"/>. The <see cref="Before"/> 
        /// value will be evaluated each time that <see cref="Validate(object, object)"/>
        /// is called by invoking the function <paramref name="before"/>.
        /// </summary>
        /// <param name="before"></param>
        public DateBeforeRule(Func<DateTime> before)
        {
            _beforeFunc = before;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender)
        {
            return value is DateTime date && date < Before ? ValidationResult.ValidResult : new ValidationResult(false, "Date after the limit!");
        }
    }

    /// <summary>
    /// Check if a <see cref="DateTime"/> property of the type <typeparamref name="T"/> come before an other <see cref="DateTime"/>
    /// property of the same object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DateBeforeRule<T> : ExtendedValidationRule where T : class
    {
        /// <summary>
        /// A function that rappresent the <see cref="DateTime"/> property that is used by <see cref="Validate(object, object)"/> to evaluate
        /// <see cref="ValidationResult"/>.
        /// </summary>
        public Func<T, DateTime> Before { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DateBeforeRule{T}"/> and initialize <see cref="Before"/> with <paramref name="before"/>.
        /// </summary>
        /// <param name="before"></param>
        public DateBeforeRule(Func<T, DateTime> before)
        {
            Before = before;
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(object value, object sender) =>
            value is DateTime date && date <= Before.Invoke((T)sender) ?
            ValidationResult.ValidResult : new(false, "Date after the limit!");
    }

}
