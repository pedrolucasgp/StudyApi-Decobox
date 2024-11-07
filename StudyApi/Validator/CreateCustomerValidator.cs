using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using StudyApi.Dto;
using StudyApi.Services.User;

namespace StudyApi.Validator
{
    public class CreateCustomerValidator : AbstractValidator<UserDto>
    {
        private readonly IUserInterface _userInterface;

        public CreateCustomerValidator(IUserInterface userInterface)
        {
            _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));

            RuleFor(u => u.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .MinimumLength(3).WithMessage("Name is too small.")
                .MaximumLength(100).WithMessage("Name is too tall.");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
                
        }
        private bool UniqueEmail(string Email) => _userInterface.Equals(Email);
    }
}
