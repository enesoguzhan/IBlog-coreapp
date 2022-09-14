using FluentValidation;
using IBlog.Entities.DTO.Blogs;

namespace IBlog.Business.Validators.Blog
{
    public class BlogsInsertDTOValidator : AbstractValidator<BlogsInsertDTO>
    {
        public BlogsInsertDTOValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Başlık boş bırakılamaz")
          .MinimumLength(10).WithMessage("Daha uzun başlık yazınız");

            RuleFor(s => s.Explanation).NotEmpty().WithMessage("İçerik boş bırakılamaz")
                .MinimumLength(10).WithMessage("Daha uzun içerik yazınız");

            RuleFor(s => s.CategoryId).NotNull().WithMessage("Kategori Boş Olamaz");
        }
    }
}
