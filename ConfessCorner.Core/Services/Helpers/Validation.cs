using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfessCorner.Core.Services.Helpers
{
    public static class Validation
    {
        public static void Validate(object obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));

            ValidationContext context = new ValidationContext(obj);

            List<ValidationResult> errors = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, errors, true);

            if(!isValid) throw new ValidationException(errors.First().ErrorMessage);
        }
    }
}
