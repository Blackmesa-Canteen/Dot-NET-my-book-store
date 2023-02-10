using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyBookStore.DAL.Command;
using MyBookStore.DAL.Command.Impl;
using MyBookStore.DAL.Entity;
using MyBookStore.DAL.Repository;

namespace MyBookStore.DAL.Core.Handler
{
    /**
     * author: xiaotian li
     *
     * CRUD command handler for book records
     */
    public class BookHandler : IRequestHandler<ReserveBookCommand, TaskResult>
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;

        public BookHandler(IMediator mediator, IBookRepository bookRepository)
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
        }

        /**
         * Get error information string list from the validation result
         */
        private IEnumerable<string> GetValidationErrInfoList(AbstractBookCommand request)
        {
            return request.ValidationResult.Errors.Select(error => error.ErrorMessage);
        }

        public async Task<TaskResult> Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
            var taskResult = new TaskResult();

            if (request.IsValid())
            {
                // if the command passed validation
            }
            else
            {
                // if the command didn't pass validation,
                // put error strings into taskResult
                taskResult.AddErrorInfo(GetValidationErrInfoList(request));
            }

            return taskResult;
        }
    }
}