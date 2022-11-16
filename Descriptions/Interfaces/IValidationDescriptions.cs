using Rules.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Descriptions.Interfaces
{
    /// <summary>
    /// Non generic part of <see cref="IValidationDescriptions{T}"/>
    /// </summary>
    public interface IValidationDescriptions
    {
        /// <summary>
        /// Get all the <see cref="ExtendedValidationRule"/> registered for a property named <paramref name="propName"/>.
        /// </summary>
        /// <param name="propName"></param>
        /// <returns><c>null</c> if there are no registered rules for the property or no property named <paramref name="propName"/>.</returns>
        IEnumerable<ExtendedValidationRule>? GetRules(string propName);
    }

    /// <summary>
    /// Interface to register <see cref="ExtendedValidationRule"/> for a <typeparamref name="T"/> class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidationDescriptions<T> : IValidationDescriptions where T : class
    {
        /// <summary>
        /// Sets which property of <typeparamref name="T"/> class to add <see cref="ExtendedValidationRule"/> for.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IValidationDescriptions<T> RulesFor(Expression<Func<T, object?>> expression);
        /// <summary>
        /// Add <see cref="ExtendedValidationRule"/> for the type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        /// <remarks><see cref="RulesFor(Expression{Func{T, object?}})"/> must be called first or an <see cref="Exception"/> is thrown.</remarks>
        IValidationDescriptions<T> AddRule(ExtendedValidationRule rule);
    }

}
