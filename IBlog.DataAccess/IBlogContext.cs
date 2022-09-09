using IBlog.DataAccess.Mappings;

namespace IBlog.DataAccess
{
    public class IBlogContext : DbContext
    {

        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<SocialLinks> SocialLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionStringSql"));
            optionsBuilder.UseSqlServer("Server=LT199;Database=IBlogDb;Trusted_Connection=True;");
            // optionsBuilder.UseSqlServer("Server=DESKTOP-58;Database=IBlogDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new BlogsMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());
            modelBuilder.ApplyConfiguration(new InteractionsMap());
            modelBuilder.ApplyConfiguration(new ImagesMap());
            modelBuilder.ApplyConfiguration(new SocialLinksMap());
        }
    }
}
