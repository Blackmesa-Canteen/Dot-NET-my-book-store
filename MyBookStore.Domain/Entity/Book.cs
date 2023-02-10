using System;

namespace MyBookStore.Domain
{
    /**
     * Author: Xiaotian Li
     */
    public class Book
    {

        public Book()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }
            

        public Book(long id, string bookId, string name, string description, string coverImgUrl)
        {
            Id = id;
            BookId = bookId;
            Name = name;
            Description = description;
            CoverImgUrl = coverImgUrl;
            
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }

        public long Id { get; set; }
        
        public string BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImgUrl { get; set; }
        
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}