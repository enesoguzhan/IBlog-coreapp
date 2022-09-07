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

            builder.HasOne(s => s.User).WithOne(s => s.SocialLinks).HasForeignKey<Users>(s => s.SocialLinksId);
        }
    }
}
