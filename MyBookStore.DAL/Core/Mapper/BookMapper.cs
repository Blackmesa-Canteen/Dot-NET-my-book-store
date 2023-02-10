using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.Core.Mapper
{
    /**
     * author: Xiaotian Li
     * ORM mapper configuration
     */
    public class BookMapper : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(book => book.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(book => book.BookId)
                .HasColumnType("CHAR(32)")
                .IsRequired();

            builder.Property(book => book.Name)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(book => book.Description)
                .HasColumnType("VARCHAR");

            builder.Property(book => book.CoverImgUrl)
                .HasColumnType("VARCHAR");

            builder.Property(book => book.UserId)
                .HasColumnType("CHAR(32)");
            
            builder.Property(book => book.CreateDate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATETIME2");
            
            builder.Property(book => book.UpdateDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("DATETIME2");

            builder.Property(book => book.IsRemoved)
                .HasDefaultValue(false)
                .HasColumnType("BIT");
            
            // data migration
            builder.HasData(
                new Book("9b0896fa-3880-4c2e-bfd6-925c87f22878", "CQRS for Dummies", "Good book.", "https://www.996workers.icu", null),
                new Book("0550818d-36ad-4a8d-9c3a-a715bf15de76", "Visual Studio Tips", "Good book 2.", "https://www.996workers.icu", null),
                new Book("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1", "NHibernate Cookbook", "Good book 3.", "https://www.996workers.icu", null)
            );
        }
    }
}