using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyBookStore.DAL.Command;
using MyBookStore.DAL.Command.Impl;
using MyBookStore.DAL.Core.Entity;
using MyBookStore.DAL.Entity;
using MyBookStore.DAL.Repository;

namespace MyBookStore.DAL.Core.Handler
{
    /**
     * author: xiaotian li
     *
     * CRUD command handler for book records
     */
    public class BookHandler : IRequestHandler<ReserveBookCommand, TaskResult>,
        IRequestHandler<UpdateBookCommand, TaskResult>
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
                var book = await _bookRepository.FindBookByBookId(request.BookId);
                if (book != null)
                {
                    book.UserId = request.UserId;
                    book.UpdateDate = DateTime.Now;
                    await _bookRepository.Update(book);
                }
                else
                {
                    var message = "BookId not found for reserve: " + request.BookId;
                    // publish error message to logger
                    await _mediator.Publish(new ErrorMessage(message), cancellationToken);
                    taskResult.AddErrorInfo(message);
                }
            }
            else
            {
                // if the command didn't pass validation,
                // put error strings into taskResult
                await _mediator.Publish(new ErrorMessage(request.ValidationResult), cancellationToken);
                taskResult.AddErrorInfo(GetValidationErrInfoList(request));
            }

            return taskResult;
        }

        public async Task<TaskResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}