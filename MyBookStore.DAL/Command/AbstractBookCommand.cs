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
    public abstract class AbstractBookCommand : ICommand, IRequest<TaskResult>
    {
        public string BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImgUrl { get; set; }
        
        public string UserId { get; set; }
        
        public ValidationResult ValidationResult { get; set; }

        /**
         * data validation for robust system
         */
        public virtual bool IsValid()
        {
            BookValidation validation = new BookValidation();
            validation.ValidateBookId();
            validation.ValidateName();
            validation.ValidateDescription();
            validation.ValidateCoverImgUrl();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}