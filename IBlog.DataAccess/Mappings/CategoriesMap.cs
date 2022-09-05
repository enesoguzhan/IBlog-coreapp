using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Mappings
{
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Blogs).WithOne(s => s.Categories).HasForeignKey(s => s.CategoryId);

            builder.ToTable("Categories");
        }
    }
}
