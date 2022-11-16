using Descriptions.Interfaces;
using Descriptions.Extensions;
using Rules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Controls;

namespace Descriptions
{
    /// <summary>
    /// Default implementation of <see cref="IValidationDescriptions{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// This class can be extended to create <see cref="IValidationDescriptions{T}"/> for a class <typeparamref name="T"/>.
    /// </remarks>
    public class ValidationDescriptions<T> : IValidationDescriptions<T> where T : class
    {
        private readonly IDictionary<string, ICollection<ExtendedValidationRule>> _extendedValidationRules = new Dictionary<string, ICollection<ExtendedValidationRule>>();
        private string? _currentProp;

        /// <inheritdoc/>
        public IValidationDescriptions<T> AddRule(ExtendedValidationRule rule)
        {
            if (_currentProp is null) throw new InvalidOperationException("Must use RulesFor before adding a rule!");
            

            if (!_extendedValidationRules.ContainsKey(_currentProp))
            {
                _extendedValidationRules.Add(_currentProp, new List<ExtendedValidationRule>());
            }

            _extendedValidationRules[_currentProp].Add(rule);

            return this;
        }

        /// <inheritdoc/>
        public IValidationDescriptions<T> RulesFor(Expression<Func<T, object?>> expression)
        {
            _currentProp = GetPropertyName(expression);
            return this;         
        }

        /// <inheritdoc/>
        public IEnumerable<ExtendedValidationRule>? GetRules(string propName)
        {
            _extendedValidationRules.TryGetValue(propName, out ICollection<ExtendedValidationRule>? rules);
            return rules;
        }

        /// <summary>
        /// Utility to get property name form <paramref name="expression"/>.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>The name of the property represented by the <paramref name="expression"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        private static string GetPropertyName(Expression<Func<T, object?>> expression) => expression.Body switch
        {
            UnaryExpression unary => unary.Operand is MemberExpression member && member.Member is PropertyInfo property ? property.Name : throw new ArgumentException("Lambda epxression must access a property!", nameof(expression)),
            MemberExpression member => member.Member is PropertyInfo property ? property.Name : throw new ArgumentException("Lambda epxression must access a property!", nameof(expression)),
            _ => throw new ArgumentException("Invalid expression!", nameof(expression))
        };
    }

}
