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
            builder.Property(s => s.CreationDatetime).HasDefaultValue(DateTime.Now);

            builder.HasMany(s => s.Blogs).WithOne(s => s.User).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.SocialLinks).WithOne(s => s.User);
            builder.HasMany(s => s.Comments).WithOne(s => s.User).HasForeignKey(s => s.UserId);

            builder.HasData(new Users
            {
                Id = new Guid("475A613B-F8D4-45EE-82EE-1003F267814E"),
                Name = "Yusuf",
                Surname = "Uçar",
                Email = "yucar@gmail.com",
                Password = "58775877",
                CreationDatetime = DateTime.Now,
                Explanation = "Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test Yusuf Uçar Açıklama Test ",
                AvatarImage = "b91f2c8d-1c82-4b86-9bb7-44ee5649bb20.jpg",
                RoleType = 0
            },
            new Users
            {
                Id = new Guid("577D0A6C-CFBE-4D1E-940A-50B9D1E6D5A3"),
                Name = "Enes Oğuzhan",
                Surname = "Aracı",
                Email = "earaci@gmail.com",
                Password = "58775877",
                CreationDatetime= DateTime.Now,
                Explanation = "Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama Test Açıklama777777777585858",
                AvatarImage = "d7f30a1e-a537-45b6-899c-dee04ecc555b.jpg",
                RoleType = 1
            });
            builder.ToTable("Users");
        }
    }
}
