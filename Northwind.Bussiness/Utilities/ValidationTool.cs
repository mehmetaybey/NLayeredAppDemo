using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Bussiness.ValidationRules.FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Northwind.Bussiness.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors.ToString());
            }
        }
    }
}
