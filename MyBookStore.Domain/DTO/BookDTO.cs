namespace MyBookStore.Domain.DTO
{
    /**
     * author: xiaotian li
     * plain object
     * 
     */
    public class BookDTO
    {
        public string BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImgUrl { get; set; }
        public string UserId { get; set; }

        public BookDTO()
        {
        }

        public BookDTO(string bookId, string name, string description, string coverImgUrl, string userId)
        {
            BookId = bookId;
            Name = name;
            Description = description;
            CoverImgUrl = coverImgUrl;
            UserId = userId;
        }
        
        
    }
}