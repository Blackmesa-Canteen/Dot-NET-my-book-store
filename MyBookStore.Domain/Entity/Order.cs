using System;

namespace MyBookStore.Domain
{
    /**
     * Author: Xiaotian Li
     */
    public class Order
    {
        public Order()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }

        public Order(long id, string orderId, int bookingNo, string customerId, string bookId)
        {
            Id = id;
            OrderId = orderId;
            BookingNo = bookingNo;
            CustomerId = customerId;
            BookId = bookId;
            
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }

        public long Id { get; set; }
        public string OrderId { get; set; }
        public int BookingNo { get; set; }
        public string CustomerId { get; set; }
        public string BookId { get; set; }
        
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}