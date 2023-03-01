using Validation.Descriptions;
using Validation.Descriptions.Extensions;
using Example.CustomValidation;
using Example.ViewModels;

namespace Example.ValidationDescriptions
{
    /// <summary>
    /// In this example we use a class to register the rules for validation in order 
    /// to separate the concern of validation from the model
    /// </summary>
    public class BookValidationDescription : ValidationDescriptions<ViewModelBook>
    {
        public BookValidationDescription()
        {
            //Register rules by chain them after RulesFor
            RulesFor(b => b.Title).NotBlank().MaxStringLenght(50);

            //Register rules using AddRules extension
            RulesFor(b => b.Author).AddRules(d =>
            {
                d.NotBlank();
                d.MaxStringLenght(50);
            });

            //Use string for numbers in case you want validation for every typed character.
            //Must set UpdateSourceTrigger = PropertyChange on the binding
            RulesFor(b => b.Pages).Numeric();

            //Check that the a book is never published before beeing written
            RulesFor(b => b.Written).DateBefore(b => b.Published);
            RulesFor(b => b.Published).DateAfter(b => b.Written);

            //Check if the email is an email format
            RulesFor(b => b.PublisherEmail).Email();

            //This is a simple way to add a custom validation rules
            RulesFor(b => b.ISBN).AddRule<ViewModelBook, ISBNRule>();

        }
    }
}
