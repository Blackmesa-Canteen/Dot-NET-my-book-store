namespace MyBookStore.DAL.Command.Impl
{
    /**
     * author: xiaotian li
     *
     * CRUD command implement object
     */
    public class CreateUserCommand : AbstractUserCommand
    {
        public CreateUserCommand()
        {
        }

        public CreateUserCommand(string userId, string name, string password, int role)
        {
            UserId = userId;
            Name = name;
            Password = password;
            Role = role;
        }

    }
}