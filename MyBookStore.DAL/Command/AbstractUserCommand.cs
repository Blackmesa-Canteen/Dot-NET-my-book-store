using FluentValidation.Results;
using MediatR;
using MyBookStore.DAL.Entity;
using MyBookStore.DAL.Validation;
using MyBookStore.Domain.Command;

namespace MyBookStore.DAL.Command
{
    /**
     * author: xiaotian li
     *
     * CRUD command object
     */
    public class AbstractUserCommand : ICommand, IRequest<TaskResult>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        
        public ValidationResult ValidationResult { get; set; }
        
        /**
         * data validation for robust system
         */
        public bool IsValid()
        {
            UserValidation validation = new UserValidation();
            
            validation.ValidateUserId();
            validation.ValidateName();
            validation.ValidatePassword();
            validation.ValidateRole();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}