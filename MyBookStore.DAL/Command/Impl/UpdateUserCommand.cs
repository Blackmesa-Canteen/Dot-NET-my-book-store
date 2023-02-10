namespace MyBookStore.DAL.Command.Impl
{
    /**
     * author: xiaotian li
     *
     * CRUD command implement object
     */
    public class UpdateUserCommand : AbstractUserCommand
    {
        public UpdateUserCommand()
        {
        }

        public UpdateUserCommand(string userId, string name, string password, int role)
        {
            UserId = userId;
            Name = name;
            Password = password;
            Role = role;
        }
    }
}