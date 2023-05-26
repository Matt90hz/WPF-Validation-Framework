using Example.ValidationDescriptions;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Validation;
using Validation.Extensions;

namespace Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ValidationRegistrations.RegisterValidation();

            base.OnStartup(e);
        }

    }
}
