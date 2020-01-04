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
                .GreaterThan(0).WithMessage("The value should be greater than 0.")
                .LessThanOrEqualTo(9999999).WithMessage("The value should be less than 9999999.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("It's necessary to inform the description.")
                .MaximumLength(50).WithMessage("The maximum allowed for the description is 50 characters.")
                .NotNull().WithMessage("It's necessary to inform the description.");

            RuleFor(c => c.UserName)
               .NotEmpty().WithMessage("It's necessary to inform the user name.")
               .MaximumLength(25).WithMessage("The maximum allowed for the user name is 25 characters.")
               .NotNull().WithMessage("It's necessary to inform the user name.");
        }
    }
}
