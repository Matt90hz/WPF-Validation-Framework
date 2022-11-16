using Validation.Interfaces;

namespace Validation
{
    /// <summary>
    /// Utility class that act as singelton contaner for <see cref="IValidationService"/>.
    /// </summary>
    /// <remarks>
    /// Use this class if no dependency injection is used in the project.
    /// </remarks>
    public static class Validator
    {
        /// <summary>
        /// Get <see cref="IValidationService"/> implemented with <see cref="Validation.ValidationService"/>.
        /// </summary>
        public static IValidationService ValidationService { get; } = new ValidationService();
    }

}