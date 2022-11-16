using Descriptions.Interfaces;
using Example.Models;
using Example.ValidationDescriptions;
using Microsoft.Extensions.DependencyInjection;
using Rules.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            //Is better use dipendency injection and register the validation service and the descriptions
            //but for the example we will use Validator static class
            Validator.ValidationService.AddValidationDescription(new BookValidationDescription());

            //example in case of use of dipendency injection
            //NB validation description must be registered inside AddValidation extension, not supported yet others ways
            //unless you grab the validation service from the service provider and register the descriptions from there
            IServiceCollection services = new ServiceCollection()
                .AddValidation(validationService =>
                {
                    validationService.AddValidationDescription<BookValidationDescription>();
                });

            base.OnStartup(e);
        }

    }
}
