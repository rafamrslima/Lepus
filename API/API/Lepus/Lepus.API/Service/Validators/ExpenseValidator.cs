using FluentValidation;
using Lepus.Domain.Entities;
using System;

namespace Lepus.Service.Validators
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Month)
                .NotEmpty().WithMessage("It's necessary to inform the month.")
                .NotNull().WithMessage("It's necessary to inform the month.")
                .InclusiveBetween(1, 12).WithMessage("The month has to be between 1 and 12.");

            RuleFor(c => c.Year)
                .NotEmpty().WithMessage("It's necessary to inform the year.")
                .NotNull().WithMessage("It's necessary to inform the year.")
                .GreaterThan(DateTime.Now.Year - 1).WithMessage($"The should be greater than {DateTime.Now.Year - 1}.");

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("It's necessary to inform the value.")
                .NotNull().WithMessage("It's necessary to inform the value.")
                .GreaterThan(0).WithMessage("The value should be greater than 0.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("It's necessary to inform the description.")
                .NotNull().WithMessage("It's necessary to inform the description.");

            RuleFor(c => c.UserName)
               .NotEmpty().WithMessage("It's necessary to inform the user name.")
               .NotNull().WithMessage("It's necessary to inform the user name.");
        }
    }
}
