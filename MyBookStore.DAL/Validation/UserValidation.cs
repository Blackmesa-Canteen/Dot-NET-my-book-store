using FluentValidation;
using MyBookStore.DAL.Command;

namespace MyBookStore.DAL.Validation
{
    public class UserValidation : AbstractValidator<AbstractUserCommand>
    {
        public void ValidateUserId()
        {
            RuleFor(obj => obj.UserId)
                .NotEmpty().WithMessage("User Id should not empty");
        }

        public void ValidateName()
        {
            RuleFor(obj => obj.Name)
                .NotEmpty().WithMessage("User name should not empty")
                .MaximumLength(128).WithMessage("User name max length: 128");
        }

        public void ValidatePassword()
        {
            
        }
    }
}