using System;
using System.Linq;
using FluentValidation.Results;
using MediatR;

namespace MyBookStore.DAL.Core.Entity
{
    /**
     * author: xiaotian li
     *
     * Notification entity for db operation error alerts
     */
    public class ErrorMessage : INotification
    {
        public string Message { get; set; }

        public ErrorMessage(string message)
        {
            Message = message;
        }

        public ErrorMessage(ValidationResult validationResult)
        {
            Message = string.Join(
                Environment.NewLine,
                validationResult.Errors?.Select(x => x.ErrorMessage) ?? Array.Empty<string>()
            );
        }
    }
}