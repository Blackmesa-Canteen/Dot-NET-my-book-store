using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyBookStore.DAL.Command;
using MyBookStore.DAL.Command.Impl;
using MyBookStore.DAL.Core.Entity;
using MyBookStore.DAL.Entity;
using MyBookStore.DAL.Repository.Impl;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.Handler
{
    /**
     * author: xiaotian li
     *
     * CRUD command handler for user records
     */
    public class UserHandler : IRequestHandler<CreateUserCommand, TaskResult>,
                               IRequestHandler<UpdateUserCommand, TaskResult>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UserHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }
        
        /**
         * Get error information string list from the validation result
         */
        private IEnumerable<string> GetValidationErrInfoList(AbstractUserCommand request)
        {
            return request.ValidationResult.Errors.Select(error => error.ErrorMessage);
        }

        public async Task<TaskResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var taskResult = new TaskResult();
            if (request.IsValid())
            {
                // if the command passed validation
                // check duplicated data
                if (await _userRepository.FindUserByUserId(request.UserId) == null)
                {
                    await _userRepository.Insert(
                        new User(
                            request.UserId,
                            request.Name,
                            request.Password,
                            request.Role
                        )
                    );
                }
                else
                {
                    var message = "The user already exists in system";
                    taskResult.AddErrorInfo(message);
                    await _mediator.Publish(new ErrorMessage(message), cancellationToken);
                }
            }
            else
            {
                // if the command didn't pass validation,
                // put error strings into taskResult
                taskResult.AddErrorInfo(GetValidationErrInfoList(request));
                await _mediator.Publish(new ErrorMessage(request.ValidationResult), cancellationToken);
            }

            return taskResult;
        }

        public async Task<TaskResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}