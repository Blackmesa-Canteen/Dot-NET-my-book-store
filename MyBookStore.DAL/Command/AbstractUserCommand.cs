using MediatR;
using MyBookStore.Domain.Command;
using MyBookStore.Domain.POJO;

namespace MyBookStore.DAL.Command
{
    /**
     * author: xiaotian li
     *
     * CRUD command object
     */
    public class AbstractUserCommand : ICommand, IRequest<TaskResult>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        
        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}