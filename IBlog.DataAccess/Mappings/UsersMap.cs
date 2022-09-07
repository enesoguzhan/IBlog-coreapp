namespace IBlog.DataAccess.Mappings
{
    public class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.Surname).HasMaxLength(50);
            builder.Property(s => s.Password).HasMaxLength(30).IsRequired();
            builder.Property(s => s.Explanation).IsRequired(false);
            builder.Property(s => s.AvatarImage).HasMaxLength(100).IsRequired(false);

            builder.HasMany(s => s.Blogs).WithOne(s => s.User).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.SocialLinks).WithOne(s => s.User).HasForeignKey<SocialLinks>(s => s.UserId);

            builder.HasMany(s => s.Comments).WithOne(s => s.User).HasForeignKey(s => s.UserId);

            builder.ToTable("Users");
        }
    }
}
