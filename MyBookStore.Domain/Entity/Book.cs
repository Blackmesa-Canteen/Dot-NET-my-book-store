using System;

namespace MyBookStore.Domain.Entity
{
    /**
     * Author: Xiaotian Li
     */
    public class Book : AbstractBaseEntity
    {

        public Book() : base()
        {
        }


        public Book(string bookId, string name, string description, string coverImgUrl, string userId) : base()
        {
            BookId = bookId;
            Name = name;
            Description = description;
            CoverImgUrl = coverImgUrl;
            UserId = userId;
        }
        
        public Book(long id, string bookId, string name, string description, string coverImgUrl, string userId) : base()
        {
            Id = id;
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