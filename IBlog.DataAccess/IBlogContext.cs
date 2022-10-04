using IBlog.DataAccess.Mappings;
using Microsoft.Extensions.Configuration;

namespace IBlog.DataAccess
{
    public class IBlogContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public IBlogContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<SocialLinks> SocialLinks { get; set; }       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionStringSql"));         
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
