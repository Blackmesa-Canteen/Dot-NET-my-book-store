using MyBookStore.DAL.Validation;

namespace MyBookStore.DAL.Command.Impl
{
    /**
     * author: xiaotian li
     *
     * CRUD command implement object
     */
    public class ReserveBookCommand : AbstractBookCommand
    {
        public ReserveBookCommand()
        {
        }

        public ReserveBookCommand(string bookId, string userId)
        {
            BookId = bookId;
            UserId = userId;
        }
        
        /**
         * override validation method
         */
        public override bool IsValid()
        {
            BookValidation validation = new BookValidation();
            validation.ValidateBookId();
            
            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}