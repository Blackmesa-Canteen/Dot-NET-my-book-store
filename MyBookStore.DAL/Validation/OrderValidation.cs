using FluentValidation;
using MyBookStore.DAL.Command;

namespace MyBookStore.DAL.Validation
{
    public class OrderValidation : AbstractValidator<AbstractOrderCommand>
    {

        public void ValidateOrderId()
        {
            RuleFor(obj => obj.OrderId)
                .NotEmpty().WithMessage("Order Id should not empty");
        }
        public void ValidateBookingNo()
        {
            RuleFor(obj => obj.BookingNo)
                .NotNull().WithMessage("Booking Number can not be null");
        }

        public void ValidateCustomerId()
        {
            RuleFor(obj => obj.CustomerId)
                .NotEmpty().WithMessage("Customer Id for bookings can not be null");
        }

        public void ValidateBookId()
        {
            RuleFor(obj => obj.BookId)
                .NotEmpty().WithMessage("Book Id for bookings can not be null");
        }
    }
}