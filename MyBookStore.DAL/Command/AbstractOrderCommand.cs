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
    public class AbstractOrderCommand : ICommand, IRequest<TaskResult>
    {
        public string OrderId { get; set; }
        public int BookingNo { get; set; }
        public long CustomerId { get; set; }
        public long BookId { get; set; }
        
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            OrderValidation validation = new OrderValidation();
            validation.ValidateBookId();
            validation.ValidateBookingNo();
            validation.ValidateCustomerId();
            validation.ValidateBookId();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}