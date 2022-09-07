using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Mappings
{
    public class SocialLinksMap : IEntityTypeConfiguration<SocialLinks>
    {
        public void Configure(EntityTypeBuilder<SocialLinks> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Linkedin).HasMaxLength(50).IsRequired(false);
            builder.Property(s => s.Facebook).HasMaxLength(50).IsRequired(false);
            builder.Property(s => s.Github).HasMaxLength(50).IsRequired(false);
            builder.Property(s => s.Twitter).HasMaxLength(50).IsRequired(false);

            builder.HasOne(s => s.User).WithOne(s => s.SocialLinks);
        }
    }
}
