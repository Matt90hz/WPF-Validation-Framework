using Rules.Base;
using System.Linq;
using System.Windows.Controls;

namespace Example.CustomValidation
{
    /// <summary>
    /// ISBN Validation rule.
    /// </summary>
    public class ISBNRule : ExtendedValidationRule
    {
        /// <summary>
        /// Evaluates if the numbare is a valid ISBN-10 code.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, object sender)
        {
            return IsISBN((string)value) ?
                ValidationResult.ValidResult :
                new ValidationResult(false, "Not a valid ISBN-10 code!");
        }

        /// <summary>
        /// A ISBN is valid if the sum of the ten digits, each multiplied by its (integer) weight, descending from 10 to 1, is a multiple of 11.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public static bool IsISBN(string isbn)
        {
            if (isbn.Where(c => char.IsNumber(c)).Count() != 10) return false;

            //Display of query skills.
            var numbers = (from c in isbn
                           where char.IsNumber(c)
                           select int.Parse(c.ToString())).ToArray();

            int chekNumber = 0;

            for (var i = 10; i > 0; i--)
            {
                chekNumber = (i * numbers[i - 1]) + chekNumber;
            }

            return chekNumber % 11 == 0;
        }
    }
}
