using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyBookStore.DAL.Core.Entity;

namespace MyBookStore.DAL.Core.Handler
{
    /**
     * author: xiaotian li
     * Log hander, used to print error messages cased by database operations
     */
    public class LogHandler : INotificationHandler<ErrorMessage>
    {
        public Task Handle(ErrorMessage message, CancellationToken cancellationToken)
        {
            var messageString = message.Message;
            
            System.Diagnostics.Debug.WriteLine(messageString);
            return Task.CompletedTask;
        }
    }
}