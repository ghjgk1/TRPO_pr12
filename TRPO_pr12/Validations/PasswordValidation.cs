using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO_pr12.Validations
{
    public class PasswordValidation :ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (value ?? "").ToString().Trim();

            if (input.Length < 8)
                return new ValidationResult(false, "Длина не меньше 8 символов");

            if (!input.Any(char.IsDigit))
                return new ValidationResult(false, "Должен содержать цифры");

            if (!input.Any(char.IsSymbol))
                return new ValidationResult(false, "Должен содержать символы");
            
            if (!input.Any(char.IsUpper))
                return new ValidationResult(false, "Должен содержать буквы в верхнем регистре");

            if (!input.Any(char.IsLower))
                return new ValidationResult(false, "Должен содержать буквы в нижнем регистре");


            return ValidationResult.ValidResult;
        }

    }
}
