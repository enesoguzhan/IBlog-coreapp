using IBlog.Business.Abstract;
using IBlog.Business.Concrete;
using IBlog.Business.UserManager;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace IBlog.Business.IoC
{
    public static class Container
    {
        public static IServiceCollection IocService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<IBlogContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBlogsService, BlogsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IImagesService, ImagesService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserManager, UserManager.UserManager>();
            services.AddScoped<ISocialLinksService, SocialLinksService>();
            services.AddScoped<ICommentsService, CommentsService>();

            return services;
        }
    }
}
