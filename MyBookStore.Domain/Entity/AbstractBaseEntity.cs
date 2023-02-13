using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBookStore.Domain
{
    /**
     * Author: Xiaotian Li
     */
    public class AbstractBaseEntity
    {
        /* primary key Id should be numeric to guarantee DBMS performance */
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsRemoved { get; set; }
        
        protected AbstractBaseEntity()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            IsRemoved = false;
        }

        public AbstractBaseEntity(DateTime createDate, DateTime updateDate, bool isRemoved)
        {
            CreateDate = createDate;
            UpdateDate = updateDate;
            IsRemoved = isRemoved;
        }
    }
}