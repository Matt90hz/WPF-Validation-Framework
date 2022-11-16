using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Validation;

namespace Example.ViewModels.Base
{
    /// <summary>
    /// Base class for all models used for define standard behaviour.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new();

        /// <summary>
        /// Default implementations of <see cref="INotifyDataErrorInfo"/>.
        /// </summary>
        public bool HasErrors => _errors.Count > 0;

        /// <summary>
        /// Invoked by <see cref="OnPropertyChange(string?)"/>.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Invoked by <see cref="OnPropertyChange(string?)"/>.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        /// <summary>
        /// Default implementations of <see cref="INotifyDataErrorInfo"/>.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return _errors.Values;
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : new List<string>();
        }

        /// <summary>
        /// Raises the events <see cref="PropertyChanged"/> and <see cref="ErrorsChanged"/>.
        /// </summary>
        /// <param name="propName"></param>
        /// <remarks>
        /// Of course is possible separate the implementations for the two events but for the sake of the example is fine.
        /// </remarks>
        protected void OnPropertyChange([CallerMemberName] string? propName = null)
        {
            //Notify property change
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

            //Notify error change
            propName ??= string.Empty;

            _errors.Remove(propName);

            List<string> errorMessagges = new();

            foreach (ValidationResult result in Validation.Validator.ValidationService.Results(this, propName))
            {
                if (!result.IsValid)
                {
                    errorMessagges.Add(result.ErrorContent.ToString() ?? string.Empty);
                }
            }

            if (errorMessagges.Count > 0) _errors.Add(propName, errorMessagges);

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propName));
        }


    }


}