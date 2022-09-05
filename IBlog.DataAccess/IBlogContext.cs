using IBlog.DataAccess.Mappings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionStringSql"));
           // optionsBuilder.UseSqlServer("Server=LT199;Database=IBlogDb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-58;Database=IBlogDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogsMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());
            modelBuilder.ApplyConfiguration(new InteractionsMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new ImagesMap());
        }
    }
}
