using FluentValidation;
using OnlineStore.Repository.Context;
using OnlineStore.Service.DTOs;

namespace OnlineStore.API.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(StoreDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid format for Email");

            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Minimum Length: 6 characters");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required");
            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}