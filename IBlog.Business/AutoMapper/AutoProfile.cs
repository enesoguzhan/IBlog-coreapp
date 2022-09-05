using AutoMapper;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.Categories;
using IBlog.Entities.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Business.AutoMapper
{
    public class AutoProfile : Profile
    {
        public AutoProfile()
        {
            #region Blogs
            CreateMap<Blogs, BlogsUpdateDTO>().ReverseMap();
            CreateMap<Blogs, LastAddedBlogsDTO>().ReverseMap();
              
            #endregion

            #region Users

            CreateMap<Users, UsersUpdateDTO>().ReverseMap();
            CreateMap<Users, AuthorsBlogsDTO>()
                .ForMember(destination => destination.NameSurname, operation => operation.MapFrom(s => s.Name + " " + s.Surname)).ReverseMap();
            CreateMap<Categories, CategoriesListCountDTO>()
                .ForMember(destination => destination.Count, operation => operation.MapFrom(s => s.Blogs.Count));

            #endregion
        }
    }
}
