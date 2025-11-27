using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using TRPO_pr12.Service;

namespace TRPO_pr12.Validations
{

    internal class LoginValidation : ValidationRule
    {
        public UsersServise _service { get; set; } = new();

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string input = (value ?? "").ToString().Trim();

            foreach (var user in _service.Users)
            {
                if (user.Login == input)
                    return new ValidationResult(false, "Логин не уникален");
            }

            if (input.Length <= 5)
                return new ValidationResult(false, "Длина не меньше 5 символов");

            return ValidationResult.ValidResult;
        }

    }
}
