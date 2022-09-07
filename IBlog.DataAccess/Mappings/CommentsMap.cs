using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Mappings
{
    public class CommentsMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.CreationDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(s => s.Status).HasDefaultValue(false);
            builder.HasOne(s => s.Blog).WithMany(s => s.Comments).HasForeignKey(s => s.BlogId);

            builder.HasOne(s => s.User).WithMany(s => s.Comments).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Comments");
        }
    }
}
