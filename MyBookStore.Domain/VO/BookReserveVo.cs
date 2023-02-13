namespace MyBookStore.Domain.VO
{
    public class BookReserveVo
    {
        public BookReserveVo(string bookId)
        {
            BookId = bookId;
        }

        public string BookId { get; set; }
    }
}