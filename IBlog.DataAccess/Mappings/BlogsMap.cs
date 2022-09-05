using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Mappings
{
    public class BlogsMap : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(150).IsRequired();
            builder.Property(s => s.Explanation).IsRequired();
            builder.Property(s => s.PublishDateTime).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(s => s.Status).HasDefaultValue(false);

            builder.HasOne(s => s.User).WithMany(s => s.Blogs).HasForeignKey(s => s.UserId);
            builder.HasMany(s => s.Comments).WithOne(s => s.Blog).HasForeignKey(s => s.BlogId);
            builder.HasMany(s => s.Interactions).WithOne(s => s.Blog).HasForeignKey(s => s.BlogId);
            builder.HasOne(s => s.Categories).WithMany(s => s.Blogs).HasForeignKey(s => s.CategoryId);
            builder.HasMany(s => s.Images).WithOne(s => s.Blog).HasForeignKey(s => s.BlogId);

            builder.ToTable("Blogs");
        }
    }
}
