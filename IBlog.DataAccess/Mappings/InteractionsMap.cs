using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Mappings
{
    public class InteractionsMap : IEntityTypeConfiguration<Interactions>
    {
        public void Configure(EntityTypeBuilder<Interactions> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.InteractionDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(s => s.InteracitonType).IsRequired();
            builder.Property(s => s.IpAddress).HasMaxLength(15);

            builder.HasOne(s => s.Blog).WithMany(s => s.Interactions).HasForeignKey(s => s.BlogId);
            builder.ToTable("Interactions");
        }
    }
}
