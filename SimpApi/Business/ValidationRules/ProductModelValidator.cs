using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ProductModelValidator : AbstractValidator<ProductModel>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("ürünün bir kategorisi olmalı");
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100).WithMessage("ürün ismi zorunlu ve 100 karakterden fazla olamaz");
            RuleFor(x => x.Url).NotEmpty().NotNull().MaximumLength(100).WithMessage("url zorunlu ve 100 karakterden fazla olamaz");
            RuleFor(x => x.Tag).NotEmpty().NotNull().MaximumLength(100).WithMessage("tagler zorunlu ve 100 karakterden fazla olamaz");
        }
    }
}
