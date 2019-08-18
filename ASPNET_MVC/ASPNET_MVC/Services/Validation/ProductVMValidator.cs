using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.ViewModels;
using FluentValidation;

namespace ASPNET_MVC.Services
{
    public class ProductVmValidator : AbstractValidator<ProductViewModel>
    {
        public ProductVmValidator()
        {
            RuleFor(m => m.EditableProduct.Name)
                .NotEmpty()
                .WithMessage("To pole jest wymagane.")
                .Length(1, 50)
                .WithMessage("Nazwa nie może zawierać więcej niż 50 znaków.");

            RuleFor(m => m.EditableProduct.Description)
                .NotEmpty()
                .WithMessage("To pole jest wymagane.")
                .Length(1, 150)
                .WithMessage("Opis nie może zawierać więcej niż 150 znaków.");
        }
    }
}
