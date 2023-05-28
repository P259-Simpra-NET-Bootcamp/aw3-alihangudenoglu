using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryModelValidator : AbstractValidator<CategoryModel>
    {
        public CategoryModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50).WithMessage("isminiz boş veya 50 karakterden fazla olmamalıdır.");
            RuleFor(x => x.Order).NotEmpty().NotNull().WithMessage("sıralama boş geçilemez");

        }
    }
}
