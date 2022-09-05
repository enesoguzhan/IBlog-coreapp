using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Mappings
{
    public class ImagesMap : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Blog).WithMany(s => s.Images).HasForeignKey(s => s.BlogId);

            builder.ToTable("Images");
        }
    }
}
