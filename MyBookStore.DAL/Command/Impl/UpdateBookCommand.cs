namespace MyBookStore.DAL.Command.Impl
{
    /**
     * author: xiaotian li
     *
     * CRUD command implement object
     */
    public class UpdateBookCommand : AbstractBookCommand
    {
        public UpdateBookCommand()
        {
        }

        public UpdateBookCommand(string bookId, string name, string description, string coverImaUrl, string userId)
        {
            BookId = bookId;
            Name = name;
            Description = description;
            CoverImgUrl = coverImaUrl;
            UserId = userId;
        }
    }
}