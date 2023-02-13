namespace MyBookStore.Domain.VO
{
    public class BookInfoVo
    {
        public BookInfoVo()
        {
        }

        public BookInfoVo(string bookId, string name, string description, string coverImgUrl, string userId)
        {
            BookId = bookId;
            Name = name;
            Description = description;
            CoverImgUrl = coverImgUrl;
            UserId = userId;
        }

        public string BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImgUrl { get; set; }
        
        /* the customer id who booked the book */
        public string UserId { get; set; }
    }
}