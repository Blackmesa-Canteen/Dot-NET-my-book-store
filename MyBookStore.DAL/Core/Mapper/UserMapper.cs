using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.Core.Mapper
{
    /**
     * author: Xiaotian Li
     * ORM mapper configuration
     */
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(obj => obj.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(obj => obj.UserId)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(obj => obj.Name)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(obj => obj.Password)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(obj => obj.Role)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(obj => obj.CreateDate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATETIME");

            builder.Property(obj => obj.UpdateDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("DATETIME");

            builder.Property(obj => obj.IsRemoved)
                .HasDefaultValue(false)
                .HasColumnType("BIT");
            
            builder.HasData(
                new User(1, "demo@996workers.icu", "demo", "jVI1KcvlMzIpFb3uJnT5+w==.5UdMqav4hxxGNpK7y3eT+aY4YoZZkLAMxN6divqZY/Y=", 1)
            );
        }
    }
}