using AutoMapper;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.Categories;
using IBlog.Entities.DTO.Users;
using System.Security.Cryptography;

namespace IBlog.Business.AutoMapper
{
    public class AutoProfile : Profile
    {
        public AutoProfile()
        {
            #region Blogs
            CreateMap<Blogs, BlogsUpdateDTO>().ReverseMap();
            CreateMap<Blogs, LastAddedBlogsDTO>().ReverseMap();
            CreateMap<Blogs,BlogsListDTO>()
                .ForMember(destination=>destination.UserName,operation=>operation.MapFrom(s=>s.User.Name + " " + s.User.Surname))
                .ForMember(destination=>destination.CategoryName,operation=>operation.MapFrom(s=>s.Categories.Name)).ReverseMap();
              
            #endregion

            #region Users

            CreateMap<Users, UsersUpdateDTO>().ReverseMap();
            CreateMap<Users, AuthorsBlogsDTO>()
                .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname)).ReverseMap();
            CreateMap<Categories, CategoriesListCountDTO>()
                .ForMember(destination => destination.Count, operation => operation.MapFrom(s => s.Blogs.Count));
            CreateMap<Users, UserListDTO>()
                .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname))
                .ForMember(destination => destination.BlogsCount, operation => operation.MapFrom(s => s.Blogs.Count))
                .ForMember(destination => destination.RoleName, operation => operation.MapFrom(s => s.RoleType == 1 ? "Yönetici" : "Yazar")).ReverseMap();

            #endregion
        }
    }
}
