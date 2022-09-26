using AutoMapper;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.Categories;
using IBlog.Entities.DTO.Comments;
using IBlog.Entities.DTO.PanelComponent;
using IBlog.Entities.DTO.Users;

namespace IBlog.Business.AutoMapper
{
    public class AutoProfile : Profile
    {
        public AutoProfile()
        {
            #region Blogs
            CreateMap<Blogs, BlogsUpdateDTO>().ReverseMap();
            CreateMap<Blogs, BlogsInsertDTO>().ReverseMap();

            CreateMap<Blogs, LastAddedBlogsDTO>().ReverseMap();
            CreateMap<Blogs, TotalBlogsCountDTO>().ReverseMap();

            CreateMap<Blogs, BlogsListDTO>()
                .ForMember(destination => destination.UserName, operation => operation.MapFrom(s => s.User.Name + " " + s.User.Surname))
                .ForMember(destination => destination.CategoryName, operation => operation.MapFrom(s => s.Categories.Name)).ReverseMap();

            CreateMap<Blogs, LastAddedBlogDTO>()
                .ForMember(destination => destination.Explanation, operation => operation.MapFrom(s => s.Explanation.Substring(0, 27) + "..."))
                .ForMember(destination => destination.Image, operation => operation.MapFrom(s => s.Images.FirstOrDefault().Name))
                .ReverseMap();


            #endregion

            #region Users

            CreateMap<Users, UsersUpdateDTO>().ReverseMap();
            CreateMap<Users, AuthorsBlogsDTO>()
                .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname)).ReverseMap();

            CreateMap<Categories, CategoriesListCountDTO>()
                .ForMember(destination => destination.Count, operation => operation.MapFrom(s => s.Blogs.Count)).ReverseMap();

            CreateMap<Users, UserListDTO>()
                .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname))
                .ForMember(destination => destination.BlogsCount, operation => operation.MapFrom(s => s.Blogs.Count))
                .ForMember(destination => destination.RoleName, operation => operation.MapFrom(s => s.RoleType == 1 ? "Yönetici" : "Yazar")).ReverseMap();

            CreateMap<Users, AuthorsCartDTO>()
              .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname))
              .ForMember(destination => destination.Explanation, operation => operation.MapFrom(s => s.Explanation.Substring(0, 27) + "..."))
              .ForMember(destination => destination.RoleName, operation => operation.MapFrom(s => s.RoleType == 1 ? "Yönetici" : "Yazar")).ReverseMap();
            CreateMap<Users, PasswordUpdateDTO>().ReverseMap();
            CreateMap<Users, TotalUsersCountDTO>().ReverseMap();

            CreateMap<Users, NewUsersDTO>()
                .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname))
                .ForMember(destination => destination.Explanation, operation => operation.MapFrom(s => s.Explanation.Substring(0, 27) + "...")).ReverseMap();

            #endregion

            #region Categories
            CreateMap<Categories, TotalCategoriesCountDTO>().ReverseMap();

            CreateMap<Categories, CategoriesInsertDTO>()
                .ReverseMap()
                .ForMember(destination => destination.Id, option => option.MapFrom(s => Guid.NewGuid()));

            CreateMap<Categories, CategoriesUpdateDTO>().ReverseMap();
            #endregion

            #region Comments
            CreateMap<Comments, CommentsInsertDTO>().ReverseMap();
            CreateMap<Comments, TotalCommentsCountDTO>().ReverseMap();
            CreateMap<Comments, CommentsListGetByBlogDTO>()
                .ForMember(destination => destination.BlogName, option => option.MapFrom(s => s.Blog.Name))
                .ForMember(destination => destination.UserNameSurname, option => option.MapFrom(s => s.User.Name + " " + s.User.Surname))
                .ReverseMap();

            #endregion
        }
    }
}
