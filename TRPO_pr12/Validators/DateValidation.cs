using System.Globalization;
using System.Windows.Controls;

namespace TRPO_pr12.Validators
{
    class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (value ?? "").ToString().Trim();

            if (input == String.Empty)
                return new ValidationResult(false, "Поле должно быть заполнено");

            if (!DateTime.TryParse(input, CultureInfo.CurrentCulture, out var result))
                return new ValidationResult(false, "Необходимо ввести дату");

            if (result > DateTime.Today)
                return new ValidationResult(false, "Дата должна быть прошедшая");

            return ValidationResult.ValidResult;
        }
    }
}
