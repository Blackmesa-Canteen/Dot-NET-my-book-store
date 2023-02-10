using FluentValidation;
using MyBookStore.DAL.Command;

namespace MyBookStore.DAL.Validation
{
    /**
     * author: xiaotian li
     *
     * validation for book database records
     */
    public class BookValidation : AbstractValidator<AbstractBookCommand>
    {
        public void ValidateBookId()
        {
            RuleFor(obj => obj.BookId)
                .NotEmpty().WithMessage("Book Id can not be empty");
        }

        public void ValidateName()
        {
            RuleFor(obj => obj.Name)
                .NotEmpty().WithMessage("Book Name can not be empty")
                .MaximumLength(128).WithMessage("Book Name max length: 128");
        }

        public void ValidateDescription()
        {
            RuleFor(obj => obj.Description)
                .MaximumLength(255).WithMessage("Book Name max length: 255");
        }

        public void ValidateCoverImgUrl()
        {
            RuleFor(obj => obj.CoverImgUrl)
                .MaximumLength(255).WithMessage("Cover image URL max length: 255");
        }
    }
}