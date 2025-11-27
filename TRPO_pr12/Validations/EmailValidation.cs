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
    internal class EmailValidation : ValidationRule
    {
        public UsersServise _service { get; set; } = new();

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            string input = (value ?? "").ToString().Trim();

            foreach (var user in _service.Users)
            {
                if (user.Email == input)
                    return new ValidationResult(false, "Email не уникален");
            }


            if (!input.Contains('@'))
                return new ValidationResult(false, "Должен содержать @");

            return ValidationResult.ValidResult;
        }
    }
}
