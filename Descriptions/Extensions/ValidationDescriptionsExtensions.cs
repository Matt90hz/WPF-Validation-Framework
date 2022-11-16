using Descriptions.Interfaces;
using Rules;
using Rules.Base;
using System;
using System.Windows.Controls;

namespace Descriptions.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IValidationDescriptions{T}"/>.
    /// </summary>
    public static partial class ValidationDescriptionsExtensions
    {
        /// <summary>
        /// Utility function to add multiple rules to the same property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="buildAction"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rules registration.</returns>
        public static IValidationDescriptions<T> AddRules<T>(this IValidationDescriptions<T> validationDescriptions, Action<IValidationDescriptions<T>> buildAction) where T : class
        {
            buildAction(validationDescriptions);
            return validationDescriptions;
        }

        /// <summary>
        /// Utility function to add rules by type rather than by instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rules registration.</returns>
        public static IValidationDescriptions<T> AddRule<T,U>(this IValidationDescriptions<T> validationDescriptions) 
            where T : class 
            where U : ExtendedValidationRule, new()
        {
            validationDescriptions.AddRule(new U());
            return validationDescriptions;
        }


        /// <summary>
        /// Add <see cref="Rules.DateAfterRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="after"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> DateAfter<T>(this IValidationDescriptions<T> validationDescriptions, DateTime after) where T : class
        {
            validationDescriptions.AddRule(new DateAfterRule(after));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="Rules.DateAfterRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="after"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> DateAfter<T>(this IValidationDescriptions<T> validationDescriptions, Func<DateTime> after) where T : class
        {
            validationDescriptions.AddRule(new DateAfterRule(after));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="Rules.DateAfterRule{T}"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="afterProperty"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> DateAfter<T>(this IValidationDescriptions<T> validationDescriptions, Func<T, DateTime?> afterProperty) where T : class
        {
            validationDescriptions.AddRule(new DateAfterRule<T>(afterProperty));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="Rules.DateBeforeRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="before"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> DateBefore<T>(this IValidationDescriptions<T> validationDescriptions, DateTime before) where T : class
        {
            validationDescriptions.AddRule(new DateBeforeRule(before));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="Rules.DateBeforeRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="before"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> DateBefore<T>(this IValidationDescriptions<T> validationDescriptions, Func<DateTime> before) where T : class
        {
            validationDescriptions.AddRule(new DateBeforeRule(before));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="DateBeforeRule{T}"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="beforeProperty"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> DateBefore<T>(this IValidationDescriptions<T> validationDescriptions, Func<T, DateTime> beforeProperty) where T : class
        {
            validationDescriptions.AddRule(new DateBeforeRule<T>(beforeProperty));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="EmailFormatRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> Email<T>(this IValidationDescriptions<T> validationDescriptions) where T : class
        {
            validationDescriptions.AddRule(new EmailFormatRule());
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="EqualToRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="value"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> EqualsTo<T>(this IValidationDescriptions<T> validationDescriptions, object value) where T : class
        {
            validationDescriptions.AddRule(new EqualToRule(value));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="EqualToRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="value"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> EqualsTo<T>(this IValidationDescriptions<T> validationDescriptions, Func<object> value) where T : class
        {
            validationDescriptions.AddRule(new EqualToRule(value));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="IntegerValuesRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> Integer<T>(this IValidationDescriptions<T> validationDescriptions) where T : class
        {
            validationDescriptions.AddRule(new IntegerValuesRule());
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="MatchingPropertyRule{T}"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="property"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> MatchingProperty<T>(this IValidationDescriptions<T> validationDescriptions, Func<T?, object?> property) where T : class
        {
            validationDescriptions.AddRule(new MatchingPropertyRule<T>(property));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="MBLimitRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="mb"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> MaxFileSize<T>(this IValidationDescriptions<T> validationDescriptions, int mb) where T : class
        {
            validationDescriptions.AddRule(new MBLimitRule(mb));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="NoBlankRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> NotBlank<T>(this IValidationDescriptions<T> validationDescriptions) where T : class
        {
            validationDescriptions.AddRule(new NoBlankRule());
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="NoSymbolsRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> NoSymblos<T>(this IValidationDescriptions<T> validationDescriptions) where T : class
        {
            validationDescriptions.AddRule(new NoSymbolsRule());
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="NotNullRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> NotNull<T>(this IValidationDescriptions<T> validationDescriptions) where T : class
        {
            validationDescriptions.AddRule(new NotNullRule());
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="NumericValuesRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> Numeric<T>(this IValidationDescriptions<T> validationDescriptions) where T : class
        {
            validationDescriptions.AddRule(new NumericValuesRule());
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="MinStingLenghtRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="lenght"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> MinStringLenght<T>(this IValidationDescriptions<T> validationDescriptions, int lenght) where T : class
        {
            validationDescriptions.AddRule(new MinStingLenghtRule(lenght));
            return validationDescriptions;
        }

        /// <summary>
        /// Add <see cref="StringLimitRule"/> to <see cref="IValidationDescriptions{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationDescriptions"></param>
        /// <param name="lenght"></param>
        /// <returns><see cref="IValidationDescriptions{T}"/> to chain rule registration.</returns>
        public static IValidationDescriptions<T> MaxStringLenght<T>(this IValidationDescriptions<T> validationDescriptions, int lenght) where T : class
        {
            validationDescriptions.AddRule(new StringLimitRule(lenght));
            return validationDescriptions;
        }
    }
}
